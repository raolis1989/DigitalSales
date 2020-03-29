using DigitalSales.Entities.Warehouse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitalSales.Data.Interfaces
{
    public interface IEntryRepository
    {
        Task<Entry> ObtainEntryAsync(int id);
        Task<Entry> Update(Entry entry);
        Task<Entry> AddEntry(Entry entry);
        Task<List<Entry>> ObtainEntriesAsync();
        Task<bool> Deactivate(int id);


    }
}
