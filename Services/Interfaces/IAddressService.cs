using eApp.Models;

namespace eApp.Services.Interfaces;

public interface IAddressService {
    Task CreateAddressForUser(int userId);
    Task<Address> GetAddressByUser(int userId);
    Task UpdateAddress(Address address, int userId);
}