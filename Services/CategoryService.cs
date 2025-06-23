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
    }
}