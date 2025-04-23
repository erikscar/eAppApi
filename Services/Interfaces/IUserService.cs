using eApp.Models;

namespace eApp.Services.Interfaces;

public interface IUserService
{
    Task<User> GetUserDetailsAsync(int userId);
    Task LoginUserAsync(User user);
    Task<ICollection<User>> GetAllUsersAsync();
    Task CreateUserAsync(User user);
    Task UpdateUserAsync(User user, int userId);
    Task DeleteUserAsync(int userId);
}
