using eApp.Models;

namespace eApp.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<ICollection<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int categoryId);
        Task<ICollection<Category>> GetCategoriesBySearchValue(string searchValue);
        Task<Category> CreateCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category, int categoryId);
        Task RemoveCategoryAsync(int categoryId);
    }
}