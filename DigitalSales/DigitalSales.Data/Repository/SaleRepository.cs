using DigitalSales.Data.Interfaces;
using DigitalSales.Entities.Sales;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalSales.Data.Repository
{
    public class SaleRepository : ISaleRepository
    {
        private readonly DbContextDigitalSales _context;
        private readonly IArticleRepository _articleRepository;

        public SaleRepository(DbContextDigitalSales context, IArticleRepository articleRepository)
        {
            _context = context;
            _articleRepository = articleRepository;
        }

        public async Task<Sale> AddSale(Sale sale)
        {
            sale.status = "ACCEPTED";
            sale.date_time = DateTime.Now;
            _context.Sales.Add(sale);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                return null;
            }

            return sale;
        }

        public async Task<bool> Deactivate(int id)
        {
            var resultSale = await ObtainSaleAsync(id);
            resultSale.status = "CANCELED";

            try
            {   
                foreach(var article in resultSale.detail_sale)
                {
                    var articlesStockNow = await _articleRepository.ObtainArticleAsync(article.idarticle);

                    articlesStockNow.Stock = article.Article.Stock + article.Quantity;

                    await _articleRepository.Update(articlesStockNow);
                }
                _context.Sales.Update(resultSale);

                return await _context.SaveChangesAsync() > 0 ? true : false;
                
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public  async Task<Sale> ObtainSaleAsync(int id)
        {
            return await _context.Sales
                .Include(c => c.detail_sale)
                .SingleOrDefaultAsync(c => c.idsale == id);
        }

        public async Task<List<Sale>> ObtainSalesFilter(string texto)
        {
            return await _context.Sales
                                .Include(i => i.User)
                                .Include(i => i.Person)
                                .Where(i => i.num_voucher.Contains(texto))
                                .OrderByDescending(i => i.idsale)
                                .ToListAsync();
        }

        public async Task<List<Sale>> ObtainSalesAsync()
        {
            try
            {
                var result = await _context.Sales
                                           .Include(p => p.Person)
                                           .Include(p => p.User)
                                           .OrderByDescending(p => p.idsale)
                                           .ToListAsync();
                return result;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public Task<Sale> Update(Sale sale)
        {
            throw new NotImplementedException();
        }

        public async  Task<List<Sale>> FilterSalesDates(DateTime dateInit, DateTime dateEnd)
        {
            return await _context.Sales
                            .Include(s => s.User)
                            .Include(s => s.Person)
                            .Where(i => i.date_time >= dateInit && i.date_time<=dateEnd)
                            .OrderByDescending(v => v.idsale)
                            .Take(100)
                            .ToListAsync();
        }

        public async  Task<List<object>> SalesMonth()
        {
            var sdsd =  await _context.Sales
                                .GroupBy(s => s.date_time.Month)
                                .Select(x => new { etiqueta = x.Key.ToString(), valor = x.Sum(v => v.total) })
                                .OrderByDescending(x => x.etiqueta)
                                .Take(12)
                                .ToListAsync();
            var rtesu =   sdsd.Cast<object>().ToList();

            return rtesu;
        }
    }
}
