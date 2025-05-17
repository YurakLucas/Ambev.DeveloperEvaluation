using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class SaleItem
    {
        public Guid Id { get; private set; }
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal Discount { get; private set; }
        public decimal TotalAmount { get; private set; }

        public SaleItem(Guid productId, int quantity, decimal unitPrice)
        {
            if (quantity <= 0)
                throw new ArgumentException("A quantidade deve ser maior que zero.");

            if (quantity > 20)
                throw new ArgumentException("Não é permitido vender mais de 20 itens do mesmo produto.");

            Id = Guid.NewGuid();
            ProductId = productId;
            Quantity = quantity;
            UnitPrice = unitPrice;
            Discount = 0;
            TotalAmount = UnitPrice * Quantity;
        }

        public void ApplyDiscount(decimal discount)
        {
            Discount = discount;
            TotalAmount = (UnitPrice * Quantity) - Discount;
        }
    }
}
