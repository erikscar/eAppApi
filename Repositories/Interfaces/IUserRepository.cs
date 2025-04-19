using eApp.Models;

namespace eApp.Interfaces;

public interface IUserRepository {
    Task<IEnumerable<User>> GetAllUsers();
    Task<User> GetUserById(int userId);
    Task CreateUser(User user);
    void UpdateUser(User user);
    Task DeleteUser(User user);
    Task Save();
}