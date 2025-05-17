using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface ISaleRepository
    {
        Task<Sale> GetByIdAsync(Guid id);
        Task<List<Sale>> GetAllAsync();
        Task AddAsync(Sale sale);
        Task UpdateAsync(Sale sale);
        Task DeleteAsync(Guid id);
    }
}
