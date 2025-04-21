using eApp.Data;
using eApp.Interfaces;
using eApp.Models;
using Microsoft.EntityFrameworkCore;

namespace eApp.Repositories;

public class UserRepository : IUserRepository
{
    private readonly EAppContext _context;

    public UserRepository(EAppContext context)
    {
        _context = context;
    }

    public async Task CreateUser(User user)
    {
        await _context.AddAsync(user);
    }

    public async Task DeleteUser(User user)
    {
        _context.Users.Remove(user);
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> GetUserById(int userId)
    {
        return await _context.Users.FindAsync(userId);
    }

    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }

    public void UpdateUser(User user)
    {
        _context.Entry(user).State = EntityState.Modified;
    }
}
