using eApp.Models;
using eApp.Models.DTOs;
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

        public async Task<ICollection<ProductDTO>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();

            if (products.Count == 0)
            {
                throw new KeyNotFoundException("Nenhum Produto Encontrado");
            }

            return products
                .Select(product => new ProductDTO
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Offer = product.Offer,
                    ImageUrl = product.ImageUrl,
                    CategoryId = product.CategoryId,
                    AverageRating =
                        product.Reviews.Count != 0
                            ? product.Reviews.Average(review => review.Rating) * 2
                            : 0,
                })
                .ToList();
        }

        public async Task<ProductDTO> GetProductByIdAsync(int productId)
        {
            var product = await _productRepository.GetProductById(productId);

            return new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Offer = product.Offer,
                ImageUrl = product.ImageUrl,
                CategoryId = product.CategoryId,
                AverageRating = product.Reviews.Count != 0
                    ? product.Reviews.Average(review => review.Rating) * 2
                    : 0,
            };
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            return await _productRepository.CreateProductAsync(product);
        }

        public async Task<ICollection<Product>> FilterProductsAsync(string searchValue)
        {
            return await _productRepository.GetProductsByFilterAsync(searchValue);
        }

        public async Task<ICollection<Product>> GetProductByCategory(string category)
        {
            return await _productRepository.GetProductByCategory(category);
        }

        public async Task RemoveProductAsync(int productId)
        {
            await _productRepository.RemoveProductAsync(productId);
        }

        public async Task UpdateProductAsync(Product product, int productId)
        {
            var productToUpdate = await _productRepository.GetProductById(productId);

            productToUpdate.Name = product.Name;
            productToUpdate.Description = product.Description;
            productToUpdate.Price = product.Price;
            productToUpdate.Offer = product.Offer;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.ImageUrl = product.ImageUrl;

            await _productRepository.UpdateProductAsync(productToUpdate);
        }
    }
}
