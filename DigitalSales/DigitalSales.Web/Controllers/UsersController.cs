using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DigitalSales.Data.Interfaces;
using DigitalSales.Entities.Users;
using DigitalSales.Web.Models.Users.User;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalSales.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UsersController(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        // GET: api/Categories
        [HttpGet("[action]")]
        [EnableCors()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> List()
        {

            try
            {
                var users = await _userRepository.ObtainUsersAsync();

                return _mapper.Map<List<UserViewModel>>(users);
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
        public async Task<ActionResult<UserViewModel>> ObtainUser(int id)
        {
            var user = await _userRepository.ObtainUserAsync(id);


            if (user == null)
            {
                return NotFound();
            }

            return _mapper.Map<UserViewModel>(user);
        }


        [HttpPut("[action]")]
        [EnableCors()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UpdateViewModel>> UpdateUser(int id, [FromBody] UpdateViewModel userobj)
        {
            if (userobj == null)
                return NotFound();
            var user = _mapper.Map<User>(userobj);

            var resultado = await _userRepository.Update(user);
            if (!resultado)
                return BadRequest();

            return userobj;
        }

        // POST: api/Categories
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("[action]")]
        [EnableCors()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserViewModel>> AddUser(AddViewModel model)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            
            if(await _userRepository.CheckEmail(model.Email))
            {
                return BadRequest("El email ya existe");
            }



            var resultPass = await _userRepository.CrearPasswordHash(model.Password);

            var user = _mapper.Map<User>(model);

            user.Password_Hash = resultPass.Item1;
            user.Password_Salt = resultPass.Item2;


            var newUser = await _userRepository.AddUser(user);

            if (newUser == null)
            {
                return BadRequest();
            }

            var newUserResult = _mapper.Map<UserViewModel>(newUser);
            return CreatedAtAction(nameof(AddUser), new { id = newUserResult.IdUser }, newUserResult);
        }

        [HttpPut("[action]/{id}")]
        [EnableCors()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeactivateUser(int id)
        {
            try
            {
                var resultado = await _userRepository.Deactivate(id);
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
        public async Task<ActionResult> ActivateUser(int id)
        {
            try
            {
                var resultado = await _userRepository.Activate(id);
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