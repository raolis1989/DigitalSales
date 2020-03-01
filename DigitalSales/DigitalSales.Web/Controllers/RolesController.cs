using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DigitalSales.Data.Interfaces;
using DigitalSales.Entities.Users;
using DigitalSales.Web.Models.Users;
using DigitalSales.Web.Models.Users.Role;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalSales.Web.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRoleRepository _roleRepository;

        public RolesController(IMapper mapper, IRoleRepository roleRepository)
        {

            _mapper = mapper;
            _roleRepository = roleRepository;
        }

        // GET: api/Categories
        [HttpGet("[action]")]
        [EnableCors()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<RoleViewModel>>> List()
        {

            try
            {
                var category = await _roleRepository.ObtainRolesAsync();

                return _mapper.Map<List<RoleViewModel>>(category);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("[action]")]
        [EnableCors()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<SelectViewModel>>> SelectActive()
        {
            try
            {
                var rol = await _roleRepository.ObtainRolesActiveAsync();

                return _mapper.Map<List<SelectViewModel>>(rol);
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
        public async Task<ActionResult<RoleViewModel>> ObtainRole(int id)
        {
            var role = await _roleRepository.ObtainRoleAsync(id);


            if (role == null)
            {
                return NotFound();
            }

            return _mapper.Map<RoleViewModel>(role);
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("[action]")]
        [EnableCors()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UpdateViewModel>> UpdateRole(int id, [FromBody] UpdateViewModel roleobj)
        {
            if (roleobj == null)
                return NotFound();
            var role = _mapper.Map<Role>(roleobj);

            var resultado = await _roleRepository.UpdateRole(role);
            if (!resultado)
                return BadRequest();

            return roleobj;
        }

        // POST: api/Categories
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("[action]")]
        [EnableCors()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RoleViewModel>> AddRole(AddViewModel model)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var role = _mapper.Map<Role>(model);

            var newRole = await _roleRepository.AddRole(role);

            if (newRole == null)
            {
                return BadRequest();
            }

            var newRoleResult = _mapper.Map<RoleViewModel>(newRole);
            return CreatedAtAction(nameof(AddRole), new { id = newRoleResult.idRole }, newRoleResult);
        }

        //// DELETE: api/Categories/5
        //[HttpDelete("[action]/{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<ActionResult> DeleteCategory(int id)
        //{

        //    try
        //    {
        //        var resultado = await _roleRepository.Eliminar(id);
        //        if (!resultado)
        //        {
        //            return BadRequest();
        //        }
        //        return NoContent();
        //    }
        //    catch (Exception excepcion)
        //    {

        //        return BadRequest();
        //    }

        //}

        [HttpPut("[action]/{id}")]
        [EnableCors()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeactivateRole(int id)
        {
            try
            {
                var resultado = await _roleRepository.Deactivate(id);
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
        public async Task<ActionResult<UpdateViewModel>> ActivateRole(int id)
        {
            try
            {
                var resultado = await _roleRepository.Activate(id);
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