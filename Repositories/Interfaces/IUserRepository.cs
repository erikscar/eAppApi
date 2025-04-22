using eApp.Models;
using eApp.Models.DTOs;

namespace eApp.Interfaces;

public interface IUserRepository {
    Task<ICollection<UserDTO>> GetAllUsersAsync();
    Task<UserDTO?> GetUserByIdAsync(int userId);
    Task CreateUserAsync(User user);
    void UpdateUser(User user);
    Task<bool> DeleteUserAsync(int userId);
    Task SaveAsync();
}