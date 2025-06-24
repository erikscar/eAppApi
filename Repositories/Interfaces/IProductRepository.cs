using eApp.Models;

namespace eApp.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<ICollection<Product>> GetAllAsync();
        Task<Product> GetProductById(int productId);
        Task<Product> CreateProductAsync(Product product);
        Task<ICollection<Product>> GetProductByCategory(string category);
        Task<ICollection<Product>> GetProductsByFilterAsync(string searchValue);
    }
}
