using Ambev.DeveloperEvaluation.Application.Dtos.Sales;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales
{
    [ApiController]
    [Route("api/sales")]
    public class SalesController : ControllerBase
    {
        private readonly SaleService _saleService;
        private readonly IMapper _mapper;

        public SalesController(SaleService saleService, IMapper mapper)
        {
            _saleService = saleService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSale([FromBody] SaleRequestDto saleDto)
        {
            var saleEntity = _mapper.Map<Sale>(saleDto);
            var createdSale = await _saleService.CreateSale(
                saleEntity.Customer,
                saleEntity.Branch,
                saleEntity.Items
            );

            var responseDto = _mapper.Map<SaleResponseDto>(createdSale);
            return CreatedAtAction(nameof(GetSaleById), new { id = responseDto.Id }, responseDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSaleById(Guid id)
        {
            var sale = await _saleService.GetSaleById(id);

            if (sale is null)
                return NotFound();

            var responseDto = _mapper.Map<SaleResponseDto>(sale);
            return Ok(responseDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSales()
        {
            var sales = await _saleService.GetAllSales();
            var responseDtos = _mapper.Map<List<SaleResponseDto>>(sales);

            return Ok(responseDtos);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSale(Guid id, [FromBody] SaleRequestDto saleDto)
        {
            var saleEntity = _mapper.Map<Sale>(saleDto);
            await _saleService.UpdateSale(
                id,
                saleEntity.Customer,
                saleEntity.Branch,
                saleEntity.Items
            );

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> CancelSale(Guid id)
        {
            await _saleService.CancelSale(id);
            return NoContent();
        }
    }
}
