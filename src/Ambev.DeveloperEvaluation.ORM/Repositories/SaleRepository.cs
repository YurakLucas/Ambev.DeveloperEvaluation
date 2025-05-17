using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Infrastructure.Repositories;

public class SaleRepository : ISaleRepository
{
    private static readonly List<Sale> _sales = new();

    public Task<Sale> GetByIdAsync(Guid id)
        => Task.FromResult(_sales.FirstOrDefault(s => s.Id == id));

    public Task<List<Sale>> GetAllAsync()
        => Task.FromResult(_sales.ToList());

    public Task AddAsync(Sale sale)
    {
        _sales.Add(sale);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Sale sale)
    {
        var existingSale = _sales.FirstOrDefault(s => s.Id == sale.Id);
        if (existingSale != null)
        {
            _sales.Remove(existingSale);
            _sales.Add(sale);
        }

        return Task.CompletedTask;
    }

    public Task DeleteAsync(Guid id)
    {
        var existingSale = _sales.FirstOrDefault(s => s.Id == id);
        if (existingSale != null)
            _sales.Remove(existingSale);

        return Task.CompletedTask;
    }
}