using eApp.Data;
using eApp.Interfaces;
using eApp.Models;
using eApp.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace eApp.Repositories;

public class UserRepository : IUserRepository
{
    private readonly EAppContext _context;

    public UserRepository(EAppContext context)
    {
        _context = context;
    }

    public async Task CreateUserAsync(User user)
    {
        await _context.AddAsync(user);
    }

    public async Task<bool> DeleteUserAsync(int userId)
    {
        var user = await _context.Users.FindAsync(userId);

        if(user != null)
        {
            _context.Users.Remove(user);
            return true;
        }

        return false;
    }

    public async Task<ICollection<UserDTO>> GetAllUsersAsync()
    {
        return await _context.Users
            .Select(u => new UserDTO { Id = u.Id, FirstName = u.FirstName, LastName = u.LastName, Email = u.Email })
            .ToListAsync();
    }

    public async Task<UserDTO?> GetUserByIdAsync(int userId)
    {
        return await _context.Users
            .Where(u => u.Id == userId)
            .Select(u => new UserDTO { Id = u.Id, FirstName = u.FirstName, LastName = u.LastName, Email = u.Email })
            .FirstOrDefaultAsync();
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void UpdateUser(User user)
    {
        _context.Entry(user).State = EntityState.Modified;
    }
}
