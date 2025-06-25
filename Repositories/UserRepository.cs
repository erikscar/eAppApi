using eApp.Data;
using eApp.Models;
using eApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eApp.Repositories;

public class UserRepository : IUserRepository
{
    private readonly EAppContext _context;

    public UserRepository(EAppContext context)
    {
        _context = context;
    }

    public async Task<ICollection<User>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User?> GetByIdAsync(int userId)
    {
        return await _context.Users.FindAsync(userId);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<ICollection<User>> GetBySearchValue(string searchValue)
    {
        string  pattern = $"%{searchValue.Trim().ToLower()}%";
        return await _context
            .Users.Where(u =>
                EF.Functions.Like(u.FirstName, pattern)
                || EF.Functions.Like(u.LastName, pattern)
                || EF.Functions.Like(u.Email, pattern)
                || EF.Functions.Like(u.Phone, pattern)
            )
            .ToListAsync();
    }

    public async Task<User?> CreateAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return user;
    }

    public async Task UpdateAsync(User user)
    {
        _context.Entry(user).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task AdminUpdateAsync(User user)
    {
        _context.Entry(user).State = EntityState.Modified;
        await _context.SaveChangesAsync();  
    }

    public async Task DeleteAsync(int userId)
    {
        User userToDelete = await _context.Users.FindAsync(userId);
        _context.Users.Remove(userToDelete);
        await _context.SaveChangesAsync();
    }
}
