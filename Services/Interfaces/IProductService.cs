using eApp.Models;

namespace eApp.Services.Interfaces
{
    public interface IProductService
    {
        Task<ICollection<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int productId);
        //Task<ICollection<Product>> GetProductsBySearchValue(string value);
        Task<ICollection<Product>> FilterProductsAsync(string? searchValue, string? category, string? brand, string? rating);
    }
}
