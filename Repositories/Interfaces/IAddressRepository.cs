using eApp.Models;

namespace eApp.Repositories.Interfaces;

public interface IAddressRepository
{
    Task CreateAddressAsync(int userId);
    Task<Address> GetAddressByUserIdAsync(int userId);
    Task UpdateAddressAsync(Address address);
}