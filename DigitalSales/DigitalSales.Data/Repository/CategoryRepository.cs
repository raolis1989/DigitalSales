using DigitalSales.Data.Interfaces;
using DigitalSales.Entities.Warehouse;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalSales.Data.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private  DbContextDigitalSales _context;

        public CategoryRepository(DbContextDigitalSales context)
        {
            _context = context;

        }


        public async Task<bool> Activate(int id)
        {
            var resultCategory = await ObtenerCategoryAsync(id);
            resultCategory.Condition = true;

            try
            {
                return await _context.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception ex)
            {

                return false;
            }
            return false;
        }

        public async Task<bool> Actualizar(Category category)
        {
            var resultCategory = await ObtenerCategoryAsync(category.IdCategory);
            resultCategory.Name = category.Name;
            resultCategory.Description = category.Description;

            try
            {
                return await _context.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception ex)
            {

                return false;
            }

        }

        public async Task<Category> Agregar(Category category)
        {
            category.Condition = true;
            _context.Add(category);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                return null;
            }

            return category;

           
        }

        public async Task<bool> Deactivate(int id)
        {
            var resultCategory = await ObtenerCategoryAsync(id);
            resultCategory.Condition = false;

            try
            {
                return await _context.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception ex)
            {

                return false;
            }
            return false;
        }

        public  async Task<bool> Eliminar(int id)
        {
            var resultcategory = await ObtenerCategoryAsync(id);

            _context.Remove(resultcategory);
            try
            {
                return (await _context.SaveChangesAsync() > 0 ? true : false);
            }
            catch (Exception excepcion)
            {
                return false;
            }
            return false;
        }

        public async Task<Category> ObtenerCategoryAsync(int id)
        {
            return await _context.Categories
                .SingleOrDefaultAsync(c=>c.IdCategory==id);
        }

        public async Task<List<Category>> ObtenerCategoriesAsync()
        {
            return await _context.Categories.OrderBy(c => c.Name)
                          .ToListAsync();
        }

 
    }
}
