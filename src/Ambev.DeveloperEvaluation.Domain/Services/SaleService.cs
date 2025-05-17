using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Services
{
    public class SaleService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly SaleItemService _saleItemService;
        private readonly ILogger<SaleService> _logger;

        public SaleService(ISaleRepository saleRepository, SaleItemService saleItemService, ILogger<SaleService> logger)
        {
            _saleRepository = saleRepository;
            _saleItemService = saleItemService;
            _logger = logger;
        }

        public async Task<Sale> CreateSale(string customer, string branch, List<SaleItem> items)
        {
            foreach (var item in items)
            {
                _saleItemService.ValidateItem(item);
                decimal discount = _saleItemService.CalculateDiscount(item.Quantity, item.UnitPrice);
                item.ApplyDiscount(discount);
            }

            var sale = new Sale(customer, branch, items);
            await _saleRepository.AddAsync(sale);

            _logger.LogInformation($"[SaleCreated] Sale {sale.SaleNumber} created.");
            return sale;
        }

        public async Task UpdateSale(Guid id, string customer, string branch, List<SaleItem> items)
        {
            var sale = await _saleRepository.GetByIdAsync(id);
            if (sale == null) throw new Exception("Sale not found");

            sale.Update(customer, branch, items);
            await _saleRepository.UpdateAsync(sale);

            _logger.LogInformation($"[SaleModified] Sale {sale.SaleNumber} modified.");
        }

        public async Task CancelSale(Guid id)
        {
            var sale = await _saleRepository.GetByIdAsync(id);
            if (sale == null) throw new Exception("Sale not found");

            sale.Cancel();
            await _saleRepository.UpdateAsync(sale);

            _logger.LogInformation($"[SaleCancelled] Sale {sale.SaleNumber} cancelled.");
        }

        public Task<Sale> GetSaleById(Guid id) => _saleRepository.GetByIdAsync(id);

        public Task<List<Sale>> GetAllSales() => _saleRepository.GetAllAsync();
    }
}
