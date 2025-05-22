using eApp.Models;

namespace eApp.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<ICollection<Product>> GetAllAsync();
        Task<Product> GetProductById(int productId);
        Task<ICollection<Product>> GetProductsByFilterAsync(string searchValue, string category, string brand, string ratings);
        IQueryable<Product> GetProductsQuery();
    }
}
