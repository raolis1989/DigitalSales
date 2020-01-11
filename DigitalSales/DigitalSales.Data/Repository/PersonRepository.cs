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
    public class PersonRepository : IPersonRepository
    {
        private readonly DbContextDigitalSales _context;

        public PersonRepository(DbContextDigitalSales context)
        {
            _context = context;
        }

        public async Task<bool> Activate(int id)
        {
            var resultPerson = await ObtainPersonAsync(id);
            resultPerson.Condition = true;

            try
            {
                return await _context.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception ex)
            {

                return false;
            }

        }

        public async Task<bool> Update(Person person)
        {
            var resultPerson = await ObtainPersonAsync(person.IdPerson);
           

            try
            {
                return await _context.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<Person> Add(Person person)
        {
            person.Condition = true;
            _context.Add(person);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                return null;
            }

            return person;
        }

        public async Task<bool> Deactivate(int id)
        {
            var resultResult = await ObtainPersonAsync(id);
            resultResult.Condition = false;

            try
            {
                return await _context.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception ex)
            {

                return false;
            }
        }


        public async Task<Person> ObtainPersonAsync(int id)
        {
            return await _context.Persons
                                .SingleOrDefaultAsync(c => c.IdPerson == id);
        }

        public async Task<List<Person>> ObtainPersonsAsync()
        {
            return await _context.Persons.OrderBy(c => c.Name)
                                .ToListAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var resultPerson = await ObtainPersonAsync(id);

            _context.Remove(resultPerson);
            try
            {
                return (await _context.SaveChangesAsync() > 0 ? true : false);
            }
            catch (Exception excepcion)
            {
                return false;
            }
        }
    }
}
