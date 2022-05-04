using Warehouse.Service.Entities;
namespace Warehouse.Service{
    public static class Extensions{
        public static ProductDto AsDto(this Product product){
            return new ProductDto(product.id,product.name,product.createdAt);
        }

        public static ProductWithQuantityDto AsDto(this Stock stock){
            return new ProductWithQuantityDto(stock.id, stock.product.name, stock.quantity);
        }

    }
}