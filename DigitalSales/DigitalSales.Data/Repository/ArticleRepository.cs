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
    public class ArticleRepository : IArticleRepository
    {
        private readonly DbContextDigitalSales _context;
        private readonly ICategoryRepository _categoryRepository;

        public ArticleRepository(DbContextDigitalSales context, ICategoryRepository categoryRepository)
        {
            _context = context;
            _categoryRepository = categoryRepository;
        }

        public async  Task<bool> Activate(int id)
        {
            var resultArticle = await ObtainArticleAsync(id);
            resultArticle.Condition = true;

            try
            {
                return await _context.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception ex)
            {

                return false;
            }
        }



        public async Task<Article> AddArticle(Article article)
        {
            article.Condition = true;

            _context.Add(article);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                return null;
            }

            var category = await _categoryRepository.ObtenerCategoryAsync(article.idCategory);

            article.Category = category;

            return article;
        }

        public async Task<bool> Deactivate(int id)
        {
            var resultArticle = await ObtainArticleAsync(id);
            resultArticle.Condition = false;

            try
            {
                return await _context.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception ex)
            {

                return false;
            }
           
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Article> ObtainArticleActiveAsync(string id)
        {
            try
            {
                return await _context.Articles
              .Include(c => c.Category)
              .Where(a => a.Condition == true)
              .FirstOrDefaultAsync(c => c.Code == id);
            }
            catch (Exception ex)
            {

                throw;
            }


          
        }

        public async Task<Article> ObtainArticleAsync(int id)
        {
            return await _context.Articles
                .Include(c => c.Category)
                .SingleOrDefaultAsync(c => c.IdArticle == id);
                
        }

        public async Task<List<Article>> ObtainArticlesAsync()
        {
            return await _context.Articles.Include(a => a.Category)
                .ToListAsync();

        

        }

        public async Task<bool> Update(Article article)
        {
            var resultArticle = await ObtainArticleAsync(article.IdArticle);
            resultArticle.idCategory = article.idCategory;
            resultArticle.Name = article.Name;
            resultArticle.Code = article.Code;
            resultArticle.Price_Sale = article.Price_Sale;
            resultArticle.Stock = article.Stock;
            resultArticle.Description = article.Description;

            try
            {
                return await _context.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception ex)
            {

                return false;
            }
           
        }
    }
}
