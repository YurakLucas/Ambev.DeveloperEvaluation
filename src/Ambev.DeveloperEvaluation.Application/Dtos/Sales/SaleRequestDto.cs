using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Dtos.Sales
{
    public class SaleRequestDto
    {
        [Required]
        public Guid CustomerId { get; set; }

        [Required]
        public Guid BranchId { get; set; }

        [Required]
        public DateTime SaleDate { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "A sale must contain at least one item.")]
        public List<SaleItemDto> Items { get; set; }
    }
}
