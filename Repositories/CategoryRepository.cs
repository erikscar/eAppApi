using eApp.Data;
using eApp.Models;
using eApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eApp.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly EAppContext _context;

        public CategoryRepository(EAppContext context)
        {
            _context = context;
        }
        public async Task<ICollection<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

    }
}
