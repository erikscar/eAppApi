using eApp.Models;
using eApp.Repositories.Interfaces;
using eApp.Services.Interfaces;

namespace eApp.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly ICartService _cartService;
    public UserService(IUserRepository userRepository, ICartService cartService)
    {
        _userRepository = userRepository;
        _cartService = cartService;
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

    public async Task<User> LoginUserAsync(User user)
    {
        var userToLogin = await _userRepository.GetByEmailAsync(user.Email);

        if (userToLogin == null || userToLogin.PasswordHash != user.PasswordHash)
        {
            throw new UnauthorizedAccessException("Credenciais Inválidas");
        }

        return userToLogin;
    }

    public async Task<User> CreateUserAsync(User user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user), "Usuário Inválido");
        }

        var userToCreate = await _userRepository.CreateAsync(user);
        await _cartService.CreateCartForUser(user.Id);
        return userToCreate;
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

        if(!string.IsNullOrWhiteSpace(user.PasswordHash))
        {
            userToUpdate.PasswordHash = user.PasswordHash;
        }

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
