using DigitalSales.Entities.Warehouse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitalSales.Data.Interfaces
{
    public interface IDetailEntryRepository
    {
        Task<List<DetailEntry>> ObtainDetailsEntrieAsync(int idEntry);
    }
}
