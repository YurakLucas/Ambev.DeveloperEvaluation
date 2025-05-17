using Ambev.DeveloperEvaluation.Application.Dtos.Sales;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Mappings;

public class SaleMappingProfile : Profile
{
    public SaleMappingProfile()
    {
        CreateMap<SaleRequestDto, Sale>()
            .ConstructUsing(dto => new Sale(
                dto.CustomerId.ToString(),
                dto.BranchId.ToString(),
                dto.Items.Select(i => new SaleItem(i.ProductId, i.Quantity, i.UnitPrice)).ToList()
            ));

        CreateMap<SaleItemDto, SaleItem>()
            .ConstructUsing(dto => new SaleItem(dto.ProductId, dto.Quantity, dto.UnitPrice));

        CreateMap<Sale, SaleResponseDto>();
        CreateMap<SaleItem, SaleItemResponseDto>();
    }
}