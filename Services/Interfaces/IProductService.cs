using eApp.Models;
using eApp.Models.DTOs;

namespace eApp.Services.Interfaces
{
    public interface IProductService
    {
        Task<ICollection<ProductDTO>> GetAllProductsAsync();
        Task<ProductDTO> GetProductByIdAsync(int productId);
        Task<ICollection<Product>> GetProductByCategory(string category);
        Task<ICollection<Product>> FilterProductsAsync(string? searchValue);
    }
}
