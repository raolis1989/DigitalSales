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
    public class DetailSaleRepository : IDetailSaleRepository
    {
        private readonly DbContextDigitalSales _context;

        public DetailSaleRepository(DbContextDigitalSales context)
        {
            _context = context;
        }
        public async Task<List<DetailSale>> ObtainDetailsSaleAsync(int idSale)
        {
            return await _context.DetailSales
                         .Include(a => a.Article)
                         .Where(d => d.idsale == idSale)
                         .ToListAsync();
        }
    }
}
