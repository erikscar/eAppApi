using eApp.Models;
using eApp.Repositories.Interfaces;
using eApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eApp.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ICollection<Product>> FilterProductsAsync(string? searchValue, string? category, string? brand, string? rating)
        {
            var query = _productRepository.GetProductsQuery();

            if(!string.IsNullOrWhiteSpace(searchValue))
            {
                query = query.Where(p => p.Name.ToLower().Contains(searchValue.ToLower()) ||
                                         p.Description.ToLower().Contains(searchValue.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(category))
            {
                query = query.Where(p => p.Category.Name == category);
            }

            if (!string.IsNullOrWhiteSpace(brand))
            {
                query = query.Where(p => p.Brand == brand);
            }

            if (!string.IsNullOrWhiteSpace(rating))
            {
                query = query.Where(p => p.Rating == rating);
            }

            return await query.ToListAsync();
        }

        public async Task<ICollection<Product>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();

            if(products.Count == 0)
            {
                throw new KeyNotFoundException("Nenhum Produto Encontrado");
            }

            return products;
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            return await _productRepository.GetProductById(productId);
        }

        //public async Task<ICollection<Product>> GetProductsBySearchValue(string value)
        //{
        //    return await _productRepository.GetProductsByFilterAsync(value);
        //}
    }
}
