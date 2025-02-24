using ECommerceAPI.Entities;
using ECommerceAPI.Features.Products.Commands.CreateProduct;
using ECommerceAPI.Features.Products.Commands.UpdateProduct;

namespace ECommerceAPI.Services.Interfaces
{
    public interface IProductService
    {
        Task<Product> CreateProductAsync(CreateProductCommandRequest command);
        Task<IEnumerable<Product>> GetProductsAsync(bool includeDeleted);
        Task<Product> GetProductByIdAsync(int id);
        Task<Product> UpdateProductAsync(UpdateProductCommandRequest command);
        Task<bool> DeleteProductAsync(int id);
      
    }
}
