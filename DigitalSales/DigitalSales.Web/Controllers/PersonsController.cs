using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DigitalSales.Data.Interfaces;
using DigitalSales.Web.Models.Sales.Person;
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
        public async Task<ActionResult<IEnumerable<PersonViewModel>>> List()
        {

            try
            {
                var person = await _personRepository.ObtainPersonsAsync();

                return _mapper.Map<List<PersonViewModel>>(person);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}