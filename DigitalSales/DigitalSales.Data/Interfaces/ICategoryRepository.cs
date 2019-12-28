using DigitalSales.Entities.Warehouse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitalSales.Data.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> ObtenerCategoriesAsync();
        Task<Category> ObtenerCategoryAsync(int id);
        Task<Category> Agregar(Category category);
        Task<bool> Actualizar(Category category);
        Task<bool> Eliminar(int id);
        Task<bool> Deactivate(int id);
        Task<bool> Activate(int id);
    }
}
