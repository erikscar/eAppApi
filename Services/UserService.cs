using eApp.Models;
using eApp.Repositories.Interfaces;
using eApp.Services.Interfaces;

namespace eApp.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ICollection<User>> GetAllUsersAsync()
    {
        var users = await _userRepository.GetAllAsync();

        if (users.Count == 0)
        {
            throw new KeyNotFoundException("Nenhum Usuário Encontrado");
        }

        return users;
    }

    public async Task<User> GetUserDetailsAsync(int userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);

        if (user == null)
        {
            throw new KeyNotFoundException("Nenhum Usuário Encontrado");
        }

        return user;
    }

    public async Task CreateUserAsync(User user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user), "Usuário Inválido");
        }

        await _userRepository.CreateAsync(user);
    }

    public async Task UpdateUserAsync(User user, int userId)
    {
        var userToUpdate = await _userRepository.GetByIdAsync(userId);

        if (userToUpdate == null)
        {
            throw new KeyNotFoundException("Usuário Não Encontrado para Atualização");
        }

        userToUpdate.FirstName = user.FirstName;
        userToUpdate.LastName = user.LastName;
        userToUpdate.Email = user.Email;

        await _userRepository.UpdateAsync(userToUpdate);
    }

    public async Task DeleteUserAsync(int userId)
    {
        var userToDelete = await _userRepository.GetByIdAsync(userId);

        if (userToDelete == null)
        {
            throw new KeyNotFoundException("Usuário Não Encontrado para Remoção");
        }

        await _userRepository.DeleteAsync(userId);
    }
}
