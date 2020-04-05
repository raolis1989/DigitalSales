using DigitalSales.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitalSales.Data.Interfaces
{
    public interface IDetailSaleRepository
    {
        Task<List<DetailSale>> ObtainDetailsSaleAsync(int idSale);
    }
}
