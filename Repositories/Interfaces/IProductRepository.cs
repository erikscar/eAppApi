using eApp.Models;

namespace eApp.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<ICollection<Product>> GetAllAsync();
        Task<Product> GetProductById(int productId);
    }
}
