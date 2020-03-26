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

        public EntryRepository(DbContextDigitalSales context)
        {
            _context = context;
        }
        public async Task<Entry> AddEntry(Entry entry)
        {
            entry.status = "ACCEPTED";
            entry.date_time = DateTime.Now;
            _context.Entries.Add(entry);
            
            
            try
            {
                await _context.SaveChangesAsync();

                //var id = entry.identry;
                //foreach (var detail in entry.Details)
                //{
                //    _context.DetailEntries.Add(detail);
                //}

                //await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                return null;
            }

            return entry;
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
