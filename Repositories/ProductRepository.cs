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
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductById(int productId)
        {
            return await _context.Products.FindAsync(productId);
        }

        public async Task<ICollection<Product>> GetProductsByFilterAsync(string searchValue, string category, string brand, string ratings)
        {
            return await _context
                .Products.Where(p =>
                    p.Name.ToLower().Contains(searchValue.ToLower())
                    || p.Description.ToLower().Contains(searchValue.ToLower())
                )
                .ToListAsync();
        }

        public IQueryable<Product> GetProductsQuery()
        {
            return  _context.Products.AsQueryable();
        }
    }
}
