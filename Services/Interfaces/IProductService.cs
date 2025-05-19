using eApp.Models;

namespace eApp.Services.Interfaces
{
    public interface IProductService
    {
        Task<ICollection<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int productId);
    }
}
