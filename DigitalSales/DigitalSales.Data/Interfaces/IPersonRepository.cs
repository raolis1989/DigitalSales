using DigitalSales.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitalSales.Data.Interfaces
{
    public interface IPersonRepository
    {
        Task<List<Person>> ObtainPersonsAsync(string type);
        Task<Person> ObtainPersonAsync(int id);
        Task<Person> Add(Person category);
        Task<bool> Update(Person category);
        Task<bool> Delete(int id);
        Task<bool> CheckEmail(string email);

    }
}
