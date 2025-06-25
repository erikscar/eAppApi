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

        public async Task<Category> GetCategoryByIdAsync(int categoryId)
        {
            return await _context.Categories.FindAsync(categoryId);
        }
        public async Task<ICollection<Category>> GetCategoryBySearchValue(string searchValue)
        {
            string pattern = $"%{searchValue.Trim().ToLower()}%";

            return await _context.Categories.Where(c =>
            EF.Functions.Like(c.Name, pattern) ||
            EF.Functions.Like(c.Description, pattern))
            .ToListAsync();
        }

        public async Task RemoveCategoryAsync(int categoryId)
        {
            var categoryToRemove = await _context.Categories.FindAsync(categoryId);
            _context.Categories.Remove(categoryToRemove);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
