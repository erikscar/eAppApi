using eApp.Data;
using eApp.Models;
using eApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eApp.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly EAppContext _context;

        public ProductRepository(EAppContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Product>> GetAllAsync()
        {
            return await _context.Products.Include(product => product.Reviews).ToListAsync();
        }

        public async Task<ICollection<Product>> GetProductByCategory(string category)
        {
            return await _context.Products.Where(p => p.Category.Name == category).ToListAsync();
        }

        public async Task<Product> GetProductById(int productId)
        {
            return await _context.Products.Include(product => product.Reviews).FirstOrDefaultAsync(p => p.Id == productId);
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<ICollection<Product>> GetProductsByFilterAsync(string searchValue)
        {
            return await _context
                .Products.Where(p =>
                    p.Name.ToLower().Contains(searchValue.ToLower())
                    || p.Description.ToLower().Contains(searchValue.ToLower())
                )
                .ToListAsync();
        }

        public async Task<Product> RemoveProductAsync(int productId)
        {
            var product = await _context.Products.FindAsync(productId);

            _context.Products.Remove(product);   
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
           _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return product;
        }
    }
}
