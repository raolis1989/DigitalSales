using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DigitalSales.Data;
using DigitalSales.Entities.Warehouse;
using DigitalSales.Web.Models.Warehouse.Category;
using AutoMapper;
using DigitalSales.Data.Repository;
using DigitalSales.Data.Interfaces;
using Microsoft.AspNetCore.Cors;

namespace DigitalSales.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly DbContextDigitalSales _context;
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(DbContextDigitalSales context, IMapper mapper, ICategoryRepository categoryRepository)
        {
            _context = context;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        // GET: api/Categories
        [HttpGet("[action]")]
        [EnableCors()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CategoryViewModel>>> List()
        {

            try
            {
                var category = await _categoryRepository.ObtenerCategoriesAsync();

                return _mapper.Map<List<CategoryViewModel>>(category);
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
        public async Task<ActionResult<CategoryViewModel>> ObtainCategory(int id)
        {
            var category = await _categoryRepository.ObtenerCategoryAsync(id);


            if (category == null)
            {
                return NotFound();
            }

            return _mapper.Map<CategoryViewModel>(category);
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("[action]")]
        [EnableCors()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UpdateViewModel>> UpdateCategory(int id, [FromBody] UpdateViewModel categoryobj)
        {
            if (categoryobj == null)
                return NotFound();
            var category = _mapper.Map<Category>(categoryobj);

            var resultado = await _categoryRepository.Actualizar(category);
            if (!resultado)
                return BadRequest();

            return categoryobj;
        }

        // POST: api/Categories
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("[action]")]
        [EnableCors()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoryViewModel>> AddCategory(AddViewModel model)
        {


            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = _mapper.Map<Category>(model);

            var newCategory = await _categoryRepository.Agregar(category);

            if(newCategory == null)
            {
                return BadRequest();
            }

            var newCategoryResult = _mapper.Map<CategoryViewModel>(newCategory);
                 return CreatedAtAction(nameof(AddCategory), new { id = newCategoryResult.IdCategory }, newCategoryResult);
        }

        // DELETE: api/Categories/5
        [HttpDelete("[action]/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteCategory(int id)
        {

            try
            {
                var resultado = await _categoryRepository.Eliminar(id);
                if(!resultado)
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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeactivateCategory(int id )
        {
            try
            {
                var resultado = await _categoryRepository.Deactivate(id);
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
        public async Task<ActionResult<UpdateViewModel>> ActivateCategory(int id)
        {
            try
            {
                var resultado = await _categoryRepository.Activate(id);
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


        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.IdCategory == id);
        }
    }
}
