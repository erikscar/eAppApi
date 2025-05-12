using eApp.Data;
using eApp.Models;
using eApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eApp.Repositories;

public class AddressRepository : IAddressRepository 
{
    private readonly EAppContext _context;

    public AddressRepository(EAppContext context)
    {
        _context = context;
    }

    public async Task CreateAddressAsync(int userId)
    {
        var address = new Address { UserId = userId};
        await _context.Addresses.AddAsync(address);
        await _context.SaveChangesAsync();
    }

    public async Task<Address> GetAddressByUserIdAsync(int userId)
    {
        return await _context.Addresses.FirstOrDefaultAsync(address => address.UserId == userId);
    }

    public async Task UpdateAddressAsync(Address address)
    {
        _context.Entry(address).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }


}
