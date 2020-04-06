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
                return await _context.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public  async Task<Sale> ObtainSaleAsync(int id)
        {
            return await _context.Sales.SingleOrDefaultAsync(c => c.idsale == id);
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
    }
}
