using DigitalSales.Data.Interfaces;
using DigitalSales.Entities.Warehouse;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalSales.Data.Repository
{
    public class EntryRepository : IEntryRepository
    {
        private readonly DbContextDigitalSales _context;
        private readonly IArticleRepository _articleRepository;

        public EntryRepository(DbContextDigitalSales context, IArticleRepository articleRepository )
        {
            _context = context;
            this._articleRepository = articleRepository;
        }
        public async Task<Entry> AddEntry(Entry entry)
        {
            entry.status = "ACCEPTED";
            entry.date_time = DateTime.Now;
            _context.Entries.Add(entry);
            
            
            try
            {
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                return null;
            }

            return entry;
        }

        public async Task<bool> Deactivate(int id)
        {
            var resultEntry = await ObtainEntryAsync(id);
            resultEntry.status = "CANCELED";


            try
            {
                foreach (var article in resultEntry.detail_entry)
                {
                    var articleStockNow = await _articleRepository.ObtainArticleAsync(article.idarticle);

                    articleStockNow.Stock = article.Article.Stock - article.Quantity;

                    await _articleRepository.Update(articleStockNow);

                }


                return await _context.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception ex)
            {

                return false;
            }       
        }

        public async Task<List<Entry>> ObtainEntriesAsync()
        {

            try 
            {
                var sd = await _context.Entries
              .Include(p => p.Person)
              .Include(p=>p.User)
              .OrderByDescending(p => p.identry)
              .ToListAsync();
                return sd; 
            }
            catch (Exception exc)
            {

                return null;
            }

       
        }

        public async Task<List<Entry>> ObtainEntriesFilter(string texto)
        {
            return await _context.Entries
                             .Include(i => i.User)
                             .Include(i => i.Person)
                             .Where(i => i.num_voucher.Contains(texto))
                             .OrderByDescending(i => i.identry)
                             .ToListAsync();
        }

        public async Task<Entry> ObtainEntryAsync(int id)
        {
            return await _context.Entries
                //.Include(c => c.Details)
                .SingleOrDefaultAsync(c => c.identry == id);
            
        }

        public Task<Entry> Update(Entry entry)
        {
            throw new NotImplementedException();
        }
    }
}
