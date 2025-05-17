using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Services
{
    public class SaleItemService
    {
        public void ValidateItem(SaleItem item)
        {
            if (item.Quantity <= 0)
                throw new ArgumentException("A quantidade deve ser maior que zero.");
            if (item.Quantity > 20)
                throw new ArgumentException("Não é permitido vender mais de 20 itens do mesmo produto.");
        }

        public decimal CalculateDiscount(int quantity, decimal unitPrice)
        {
            if (quantity >= 4 && quantity < 10)
                return (unitPrice * quantity) * 0.10m;
            if (quantity >= 10 && quantity <= 20)
                return (unitPrice * quantity) * 0.20m;
            return 0;
        }
    }
}
