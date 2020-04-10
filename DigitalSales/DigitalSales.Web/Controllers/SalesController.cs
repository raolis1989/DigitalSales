using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DigitalSales.Data.Interfaces;
using DigitalSales.Entities.Sales;
using DigitalSales.Web.Models.Sales.Sales;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalSales.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISaleRepository _saleRepository;
        private readonly IDetailSaleRepository _detailSaleRepository;

        public SalesController(IMapper mapper, ISaleRepository saleRepository, IDetailSaleRepository detailSaleRepository)
        {
            _mapper = mapper;
            _saleRepository = saleRepository;
            _detailSaleRepository = detailSaleRepository;
        }

        [HttpGet("[action]")]
        [EnableCors()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles="Seller, Admin")]
        public async Task<ActionResult<IEnumerable<SalesViewModel>>> List()
        {
            try
            {
                var sales = await _saleRepository.ObtainSalesAsync();
                return _mapper.Map<List<SalesViewModel>>(sales);
            }
            catch (Exception ex)
            {

                return BadRequest();
            }

        }

        [HttpGet("[action]/{DateInit}/{DateEnd}")]
        [EnableCors()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles="Seller, Admin")]
        public async Task<ActionResult<IEnumerable<SalesViewModel>>> FilterDates()
        {
            try
            {
                var sales = await _saleRepository.ObtainSalesAsync();
                return _mapper.Map<List<SalesViewModel>>(sales);
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
        [Authorize(Roles = "Admin,  Seller")]
        public async Task<ActionResult<SaleResultAddViewModel>> AddSale(AddSaleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sale = _mapper.Map<Sale>(model);

            var newSale = await _saleRepository.AddSale(sale);
            if (newSale == null)
            {
                return BadRequest();
            }
            try
            {
                var newSaleResult = _mapper.Map<SaleResultAddViewModel>(newSale);
                return CreatedAtAction(nameof(AddSale), new { id = newSaleResult.IdSale}, newSaleResult);
            }
            catch (Exception ex)
            {

                return null;
            }


        }


        [HttpGet("[action]/{id}")]
        [EnableCors()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Admin,  Seller")]
        public async Task<ActionResult<IEnumerable<DetailSaleViewModel>>> ListDetailSale(int id)
        {
            try
            {
                var detailsSale = await _detailSaleRepository.ObtainDetailsSaleAsync(id);
                return _mapper.Map<List<DetailSaleViewModel>>(detailsSale);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpPut("[action]/{id}")]
        [EnableCors()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AnulateSale(int id)
        {
            try
            {
                var resultado = await _saleRepository.Deactivate(id);
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


        [HttpGet("[action]/{texto}")]
        [EnableCors()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Admin,  Seller")]
        public async Task<ActionResult<IEnumerable<SalesViewModel>>> ListSalesFilter(string texto)
        {

            try
            {
                var entries = await _saleRepository.ObtainSalesFilter(texto);

                return _mapper.Map<List<SalesViewModel>>(entries);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

    }
}