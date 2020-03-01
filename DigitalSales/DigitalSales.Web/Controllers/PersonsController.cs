using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DigitalSales.Data.Interfaces;
using DigitalSales.Entities.Sales;
using DigitalSales.Web.Models.Sales.Person;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalSales.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPersonRepository _personRepository;

        public PersonsController(IMapper mapper, IPersonRepository personRepository)
        {
            _mapper = mapper;
            _personRepository = personRepository;
        }


        [HttpGet("[action]")]
        [EnableCors()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Admin,  Seller")]
        public async Task<ActionResult<IEnumerable<PersonViewModel>>> ListClients()
        {

            try
            {
                var person = await _personRepository.ObtainPersonsAsync("Client");

                return _mapper.Map<List<PersonViewModel>>(person);
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
        [Authorize(Roles = "Admin,  Warehouse")]
        public async Task<ActionResult<IEnumerable<PersonViewModel>>> ListProviders()
        {

            try
            {
                var person = await _personRepository.ObtainPersonsAsync("Provider");

                return _mapper.Map<List<PersonViewModel>>(person);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpGet("[action]/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PersonViewModel>> ObtainPerson(int id)
        {
            var person = await _personRepository.ObtainPersonAsync(id);


            if (person == null)
            {
                return NotFound();
            }

            return _mapper.Map<PersonViewModel>(person);
        }



        [HttpPost("[action]")]
        [EnableCors()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Admin,  Warehouse, Seller")]
        public async Task<ActionResult<PersonViewModel>> AddPerson(AddViewModel model)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            if (await _personRepository.CheckEmail(model.Email))
            {
                return BadRequest("El email ya existe");
            }





            var person = _mapper.Map<Person>(model);

      


            var newPerson = await _personRepository.Add(person);

            if (newPerson == null)
            {
                return BadRequest();
            }

            var newPersonResult = _mapper.Map<PersonViewModel>(newPerson);
            return CreatedAtAction(nameof(AddPerson), new { id = newPersonResult.IdPerson }, newPersonResult);
        }


        [HttpPut("[action]")]
        [EnableCors()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Admin,  Warehouse, Seller")]
        public async Task<ActionResult<UpdateViewModel>> UpdateClient(int id, [FromBody] UpdateViewModel userobj)
        {

            if(!ModelState.IsValid)
            {
                BadRequest();       
            }

            if (userobj == null)
                return NotFound();
            var user = _mapper.Map<Person>(userobj);



            var resultado = await _personRepository.Update(user);
            if (!resultado)
                return BadRequest();

            return userobj;
        }
    }
}