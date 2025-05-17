using Ambev.DeveloperEvaluation.Domain.Entities;

public class Sale
{
    public Guid Id { get; private set; }
    public string SaleNumber { get; private set; }
    public DateTime SaleDate { get; private set; }
    public string Customer { get; private set; }
    public decimal TotalAmount { get; private set; }
    public string Branch { get; private set; }
    public List<SaleItem> Items { get; private set; }
    public bool IsCancelled { get; private set; }

    public Sale(string customer, string branch, List<SaleItem> items)
    {
        Id = Guid.NewGuid();
        SaleNumber = $"SALE-{new Random().Next(1000, 9999)}";
        SaleDate = DateTime.UtcNow;
        Customer = customer;
        Branch = branch;
        Items = items;
        TotalAmount = items.Sum(i => i.TotalAmount);
        IsCancelled = false;
    }

    public void Update(string customer, string branch, List<SaleItem> items)
    {
        Customer = customer;
        Branch = branch;
        Items = items;
        TotalAmount = items.Sum(i => i.TotalAmount);
    }

    public void Cancel()
    {
        IsCancelled = true;
    }
}