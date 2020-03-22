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
        Task<List<Article>> ObtainArticlesForNameAsync(string Name);

        Task<Article> ObtainArticleAsync(int id);
        Task<Article> ObtainArticleActiveAsync(string code);
        Task<bool> Update(Article article);
        Task<Article> AddArticle(Article article);
        Task<bool> Delete(int id);
        Task<bool> Deactivate(int id);
        Task<bool> Activate(int id);

    }
}
