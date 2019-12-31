using DigitalSales.Data.Interfaces;
using DigitalSales.Entities.Warehouse;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitalSales.Data.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly DbContextDigitalSales _context;

        public ArticleRepository(DbContextDigitalSales context)
        {
            _context = context;
        }
        public Task<Article> AddArticle(Article article)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Article> ObtainArticleAsync(int id)
        {
            return await _context.Articles
                .Include(c => c.Category.Name)
                .SingleOrDefaultAsync(c => c.IdArticle == id);
                
        }

        public async Task<List<Article>> ObtainArticlesAsync()
        {
            var sdsd= await _context.Articles.Include(a => a.Category)
                .ToListAsync();

            return sdsd;

        }
    }
}
