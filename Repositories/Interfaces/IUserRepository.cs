using eApp.Models;

namespace eApp.Repositories.Interfaces;

public interface IUserRepository
{
    Task<ICollection<User>> GetAllAsync();
    Task<User?> GetByIdAsync(int userId);
    Task<ICollection<User?>> GetBySearchValue(string searchValue);
    Task<User?> GetByEmailAsync(string userEmail);
    Task<User> CreateAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(int userId);
}
