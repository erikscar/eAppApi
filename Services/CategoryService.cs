using eApp.Models;
using eApp.Repositories.Interfaces;
using eApp.Services.Interfaces;

namespace eApp.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<ICollection<Category>> GetCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();

            if (categories == null)
            {
                throw new KeyNotFoundException("Não Existe Categorias Cadastradas");
            }

            return categories;
        }

        public async Task<Category> GetCategoryByIdAsync(int categoryId)
        {
            return await _categoryRepository.GetCategoryByIdAsync(categoryId);
        }

        public async Task<ICollection<Category>> GetCategoriesBySearchValue(string searchValue)
        {
            return await _categoryRepository.GetCategoryBySearchValue(searchValue);
        }


        public async Task RemoveCategoryAsync(int categoryId)
        {
            await _categoryRepository.RemoveCategoryAsync(categoryId);
        }

        public async Task UpdateCategoryAsync(Category category, int categoryId)
        {
            var categoryToUpdate = await _categoryRepository.GetCategoryByIdAsync(categoryId);
            categoryToUpdate.Name = category.Name;
            categoryToUpdate.Description = categoryToUpdate.Description;
            categoryToUpdate.ImageUrl = categoryToUpdate.ImageUrl;
            await _categoryRepository.UpdateCategoryAsync(categoryToUpdate);
        }
    }
}