using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DigitalSales.Data.Interfaces;
using DigitalSales.Entities.Warehouse;
using DigitalSales.Web.Models.Warehouse.Article;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Admin,  Warehouse")]
        public async Task<ActionResult<IEnumerable<ArticleViewModel>>> List()
        {

            try
            {
                var articles = await _articleRepository.ObtainArticlesAsync();

                return _mapper.Map<List<ArticleViewModel>>(articles);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("[action]/{text}")]
        [EnableCors()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Admin,  Warehouse")]
        public async Task<ActionResult<IEnumerable<ArticleViewModel>>> ListEntry(string text)
        {

            try
            {
                var articles = await _articleRepository.ObtainArticlesForNameAsync(text);

                return _mapper.Map<List<ArticleViewModel>>(articles);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }



        [HttpGet("[action]/{text}")]
        [EnableCors()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Admin,  Seller")]
        public async Task<ActionResult<IEnumerable<ArticleViewModel>>> ListSale(string text)
        {

            try
            {
                var articles = await _articleRepository.ObtainArticlesForSale(text);

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
        [Authorize(Roles = "Admin,  Warehouse")]
        public async Task<ActionResult<ArticleViewModel>> ObtainArticle(int id)
        {
            var article = await _articleRepository.ObtainArticleAsync(id);


            if (article == null)
            {
                return NotFound();
            }

            return _mapper.Map<ArticleViewModel>(article);
        }

        // GET: api/Categories/obtainArticleforcode
        [HttpGet("[action]/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Admin,  Warehouse")]
        public async Task<ActionResult<ArticleViewModel>> ObtainArticleForCode(string id)
        {
            var article = await _articleRepository.ObtainArticleActiveAsync(id);


            if (article == null)
            {
                return NotFound();
            }

            return _mapper.Map<ArticleViewModel>(article);
        }



        [HttpGet("[action]/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Admin,  Warehouse")]
        public async Task<ActionResult<ArticleViewModel>> ObtainArticleForCodeForSale(string id)
        {
            var article = await _articleRepository.ObtainArticleForSale(id);


            if (article == null)
            {
                return NotFound();
            }

            return _mapper.Map<ArticleViewModel>(article);
        }




        [HttpPut("[action]")]
        [EnableCors()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Admin,  Warehouse")]
        public async Task<ActionResult<UpdateViewModel>> UpdateArticle(int id, [FromBody] UpdateViewModel articleobj)
        {
            if (articleobj == null)
                return NotFound();
            var article = _mapper.Map<Article>(articleobj);

            var resultado = await _articleRepository.Update(article);
            if (!resultado)
                return BadRequest();

            return articleobj;
        }

        // POST: api/Categories
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("[action]")]
        [EnableCors()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Admin,  Warehouse")]
        public async Task<ActionResult<ArticleViewModel>> AddArticle(AddViewModel model)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var article = _mapper.Map<Article>(model);

            var newArticle = await _articleRepository.AddArticle(article);

            if (newArticle == null)
            {
                return BadRequest();
            }

            var newArticleResult = _mapper.Map<ArticleViewModel>(newArticle);
            return CreatedAtAction(nameof(AddArticle), new { id = newArticleResult.IdArticle }, newArticleResult);
        }

        [HttpPut("[action]/{id}")]
        [EnableCors()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Admin,  Warehouse")]
        public async Task<ActionResult> DeactivateArticle(int id)
        {
            try
            {
                var resultado = await _articleRepository.Deactivate(id);
                if (!resultado)
                {
                    return BadRequest();
                }
                return NoContent();
            }
            catch (Exception excepcion)
            {

                return BadRequest();
            }
        }

        [HttpPut("[action]/{id}")]
        [EnableCors()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Admin,  Warehouse")]
        public async Task<ActionResult> ActivateArticle(int id)
        {
            try
            {
                var resultado = await _articleRepository.Activate(id);
                if (!resultado)
                {
                    return BadRequest();
                }
                return NoContent();
            }
            catch (Exception excepcion)
            {

                return BadRequest();
            }

        }
    }
}