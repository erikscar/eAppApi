using eApp.Models;

namespace eApp.Repositories.Interfaces;

public interface IUserRepository
{
    Task<ICollection<User>> GetAllAsync();
    Task<User?> GetByIdAsync(int userId);
    Task<User?> GetByEmailAsync(string userEmail);
    Task CreateAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(int userId);
}
