using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Dtos.Sales
{
    public class SaleItemDto
    {
        [Required]
        public Guid ProductId { get; set; } 

        [Required]
        [Range(1, 20, ErrorMessage = "Quantity must be between 1 and 20.")]
        public int Quantity { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Unit price must be greater than zero.")]
        public decimal UnitPrice { get; set; }

        public decimal Discount { get; set; }
    }
}
