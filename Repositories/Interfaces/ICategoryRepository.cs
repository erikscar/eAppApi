using eApp.Models;

namespace eApp.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<ICollection<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int categoryId);
        Task<ICollection<Category>> GetCategoryBySearchValue(string searchValue);
        Task UpdateCategoryAsync(Category category);
        Task RemoveCategoryAsync(int categoryId);
    }
}