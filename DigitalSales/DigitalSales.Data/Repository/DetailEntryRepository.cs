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
    public class DetailEntryRepository : IDetailEntryRepository
    {
        private readonly DbContextDigitalSales _context;

        public DetailEntryRepository(DbContextDigitalSales context)
        {
            _context = context;
        }
        public async  Task<List<DetailEntry>> ObtainDetailsEntrieAsync(int idEntry)
        {
            return await _context.DetailEntries
                .Include(a => a.Article)
                .Where(d => d.identry == idEntry)
                .ToListAsync();
        }
    }
}
