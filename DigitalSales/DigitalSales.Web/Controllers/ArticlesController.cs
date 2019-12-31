using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DigitalSales.Data.Interfaces;
using DigitalSales.Web.Models.Warehouse.Article;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalSales.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IArticleRepository _articleRepository;

        public ArticlesController(IMapper mapper, IArticleRepository articleRepository)
        {
            _mapper = mapper;
            _articleRepository = articleRepository;
        }

        // GET: api/Categories
        [HttpGet("[action]")]
        [EnableCors()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ArticleViewModel>>> List()
        {

            try
            {
                var articles = await _articleRepository.ObtainArticlesAsync();

                //foreach (var element in articles)
                //{
                //    var article = new ArticleViewModel
                //    {
                //        IdArticle = element.IdArticle,
                //        IdCategory = element.idCategory,
                //        Category = element.Category.Name,
                //        Code = element.Code,
                //        Name = element.Name,
                //        Price_Sale = element.Price_Sale,
                //        Stock = element.Stock,
                //        Description= element.Description
   
                //        };
                //}

                    return _mapper.Map<List<ArticleViewModel>>(articles);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET: api/Categories/5
        [HttpGet("[action]/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ArticleViewModel>> ObtainArticle(int id)
        {
            var article = await _articleRepository.ObtainArticleAsync(id);


            if (article == null)
            {
                return NotFound();
            }

            return _mapper.Map<ArticleViewModel>(article);
        }
    }
}