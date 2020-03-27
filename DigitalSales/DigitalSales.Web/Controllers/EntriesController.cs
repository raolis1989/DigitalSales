using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DigitalSales.Data.Interfaces;
using DigitalSales.Entities.Warehouse;
using DigitalSales.Web.Models.Warehouse.Entry;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalSales.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class EntriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEntryRepository _entryRepository;

        public EntriesController(IMapper mapper, IEntryRepository entryRepository)
        {
            _mapper = mapper;
            _entryRepository = entryRepository;
        }

        [HttpGet("[action]")]
        [EnableCors()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Admin,  Warehouse")]
        public async Task<ActionResult<IEnumerable<EntryViewModel>>> List()
       {

            try
            {
                var entries = await _entryRepository.ObtainEntriesAsync();

                return _mapper.Map<List<EntryViewModel>>(entries);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpPost("[action]")]
        [EnableCors()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Admin,  Warehouse")]
        public async Task<ActionResult<EntryResultAddViewModel>> AddEntry(AddEntryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entry = _mapper.Map<Entry>(model);

            var newEntry = await _entryRepository.AddEntry(entry);
            if (newEntry == null)
            {
                return BadRequest();
            }
            try
            {
                var newEntryResult = _mapper.Map<EntryResultAddViewModel>(newEntry);
                return CreatedAtAction(nameof(AddEntry), new { id = newEntryResult.IdEntry }, newEntryResult);
            }
            catch (Exception ex)
            {

                return null;
            }
            
           
        }
    }
}