using DigitalSales.Entities.Warehouse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitalSales.Data.Interfaces
{
    public interface IArticleRepository
    {
        Task<List<Article>> ObtainArticlesAsync();

        Task<Article> ObtainArticleAsync(int id);

        Task<Article> AddArticle(Article article);
        Task<bool> Eliminar(int id);
        
    }
}
