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

        public async Task<ICollection<Product>> FilterProductsAsync(string searchValue)
        {
            return await _productRepository.GetProductsByFilterAsync(searchValue);
        }

        public async Task<ICollection<Product>> GetProductByCategory(string category)
        {
            return await _productRepository.GetProductByCategory(category);
        }
    }
}
