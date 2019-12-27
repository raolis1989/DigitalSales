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
            var category = await _context.Categories.FindAsync(id);

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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateCategory( UpdateViewModel category)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(category.IdCategory<=0)
            {
                return BadRequest();
            }

            var resultCategory = await _context.Categories.FirstOrDefaultAsync(c => c.IdCategory == category.IdCategory);

            if(resultCategory==null)
            {
                return NotFound();
            }

             resultCategory = _mapper.Map<Category>(category);

            //resultCategory.Name = category.Name;
            //resultCategory.Description = category.Description;

           
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }

            return Ok();
        }

        // POST: api/Categories
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Category>> AddCategory(AddViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newCategory = _mapper.Map<Category>(model);
            newCategory.Condition = true;
            _context.Categories.Add(newCategory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return Ok();
        }

        // DELETE: api/Categories/5
        [HttpDelete("[action]/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Category>> DeleteCategory(int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }



            return Ok(category);
        }

        [HttpPut("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeactivateCategory(int id)
        {
 
            if (id <=  0)
            {
                return BadRequest();
            }

       

            var resultCategory = await _context.Categories.FirstOrDefaultAsync(c => c.IdCategory == id);

            // _context.Entry(category).State = EntityState.Modified;

            if (resultCategory == null)
            {
                return NotFound();
            }

            resultCategory.Condition = false;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPut("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> ActivateCategory(int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }



            var resultCategory = await _context.Categories.FirstOrDefaultAsync(c => c.IdCategory == id);

            // _context.Entry(category).State = EntityState.Modified;

            if (resultCategory == null)
            {
                return NotFound();
            }

            resultCategory.Condition  = true;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }

            return Ok();
        }


        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.IdCategory == id);
        }
    }
}
