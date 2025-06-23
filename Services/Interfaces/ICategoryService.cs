using eApp.Models;

namespace eApp.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<ICollection<Category>> GetCategoriesAsync();
    }
}