using DigitalSales.Data.Interfaces;
using DigitalSales.Entities.Sales;
using System;
using System.Collections.Generic;

using System.Text;
using System.Threading.Tasks;

namespace DigitalSales.Data.Repository
{
    public class PersonRepository : IPersonRepository
    {
        public Task<bool> Activate(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Actualizar(Person category)
        {
            throw new NotImplementedException();
        }

        public Task<Person> Agregar(Person category)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Deactivate(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Person>> ObtainCategoriesActiveAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Person> ObtainPersonAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Person>> ObtainPersonsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
