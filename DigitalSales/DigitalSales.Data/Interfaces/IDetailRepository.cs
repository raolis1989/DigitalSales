using DigitalSales.Entities.Warehouse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitalSales.Data.Interfaces
{
    public interface IDetailRepository
    {
        Task<DetailEntry> ObtainEntryAsync(int id);
        Task<DetailEntry> Update(DetailEntry entry);
        Task<DetailEntry> AddEntry(DetailEntry entry);
    }
}
