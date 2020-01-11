using DigitalSales.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitalSales.Data.Interfaces
{
    public interface IPersonRepository
    {
        Task<List<Person>> ObtainPersonsAsync();
        Task<Person> ObtainPersonAsync(int id);
        Task<Person> Agregar(Person category);
        Task<bool> Actualizar(Person category);
        Task<bool> Eliminar(int id);
        Task<bool> Deactivate(int id);
        Task<bool> Activate(int id);
        Task<List<Person>> ObtainCategoriesActiveAsync();
    }
}
