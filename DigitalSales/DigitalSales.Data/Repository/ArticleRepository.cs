using DigitalSales.Data.Interfaces;
using DigitalSales.Entities.Warehouse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitalSales.Data.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        public Task<Article> AddArticle(Article article)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Article> ObtainArticleAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Article>> ObtainArticlesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
