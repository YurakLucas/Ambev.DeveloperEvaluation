using Xunit;
using FluentAssertions;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Services;
using System;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.UnitTests;

public class SaleServiceTests
{
    private readonly SaleItemService _saleItemService = new();

    [Fact]
    public void CreateSale_ShouldApply10PercentDiscount_WhenQuantityIsBetween4And9()
    {
        // Arrange
        var saleItems = new List<SaleItem>
        {
            new(Guid.NewGuid(), 5, 100m)
        };

        var sale = new Sale("Customer", "Branch", saleItems);

        // Act
        foreach (var item in sale.Items)
        {
            var discount = _saleItemService.CalculateDiscount(item.Quantity, item.UnitPrice);
            item.ApplyDiscount(discount);
        }

        // Assert
        sale.Items[0].Discount.Should().Be(50m);
        sale.Items[0].TotalAmount.Should().Be(450m);
    }

    [Fact]
    public void CreateSale_ShouldApply20PercentDiscount_WhenQuantityIsBetween10And20()
    {
        var saleItems = new List<SaleItem>
        {
            new(Guid.NewGuid(), 15, 100m)
        };

        var sale = new Sale("Customer", "Branch", saleItems);

        foreach (var item in sale.Items)
        {
            var discount = _saleItemService.CalculateDiscount(item.Quantity, item.UnitPrice);
            item.ApplyDiscount(discount);
        }

        sale.Items[0].Discount.Should().Be(300m);
        sale.Items[0].TotalAmount.Should().Be(1200m);
    }

    [Fact]
    public void CreateSale_ShouldThrowException_WhenQuantityGreaterThan20()
    {
        Action action = () => new SaleItem(Guid.NewGuid(), 25, 100m);

        action.Should()
            .Throw<ArgumentException>()
            .WithMessage("Não é permitido vender mais de 20 itens do mesmo produto.");
    }

    [Fact]
    public void CreateSale_ShouldHaveNoDiscount_WhenQuantityLessThan4()
    {
        var saleItems = new List<SaleItem>
        {
            new(Guid.NewGuid(), 3, 100m)
        };

        var sale = new Sale("Customer", "Branch", saleItems);

        foreach (var item in sale.Items)
        {
            var discount = _saleItemService.CalculateDiscount(item.Quantity, item.UnitPrice);
            item.ApplyDiscount(discount);
        }

        sale.Items[0].Discount.Should().Be(0m);
        sale.Items[0].TotalAmount.Should().Be(300m);
    }
}