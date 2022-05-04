using System;
namespace Warehouse.Service{
public record ProductDto(Guid id, string name, DateTime CreatedAt);
public record CreateProductDto(string name);
public record ProductWithQuantityDto(Guid id, string name, float quantity);
public record CreateProductWithQuantityDto(Guid productId,float quantity);
}