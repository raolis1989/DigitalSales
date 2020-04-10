using DigitalSales.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitalSales.Data.Interfaces
{
    public interface ISaleRepository
    {
        Task<Sale> ObtainSaleAsync(int id);
        Task<Sale> Update(Sale sale);
        Task<Sale> AddSale(Sale sale);
        Task<List<Sale>> ObtainSalesAsync();
        Task<bool> Deactivate(int id);

        Task<List<Sale>> ObtainSalesFilter(string texto);
        Task<List<Sale>> FilterSalesDates(DateTime dateInit, DateTime dateEnd);
    }
}
