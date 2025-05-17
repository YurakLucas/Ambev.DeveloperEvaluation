using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Dtos.Sales
{
    public class SaleResponseDto
    {
        public Guid Id { get; set; }
        public string SaleNumber { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsCancelled { get; set; }
        public List<SaleItemResponseDto> Items { get; set; }
    }
}
