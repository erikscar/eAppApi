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
    }
}
