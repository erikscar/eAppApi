using eApp.Models;
using eApp.Models.DTOs;

namespace eApp.Services.Interfaces
{
    public interface IProductService
    {
        Task<ICollection<ProductDTO>> GetAllProductsAsync();
        Task<ProductDTO> GetProductByIdAsync(int productId);
        Task<Product> CreateProductAsync(Product product);
        Task<ICollection<Product>> GetProductByCategory(string category);
        Task<ICollection<Product>> FilterProductsAsync(string? searchValue);
        Task UpdateProductAsync(Product product, int productId);   
        Task RemoveProductAsync(int productId);
    }
}
