using eApp.Models;
using eApp.Repositories.Interfaces;

namespace eApp.Services.Interfaces;

public class AddressService : IAddressService
{
    private readonly IAddressRepository _addressRepository;

    public AddressService(IAddressRepository addressRepository)
    {
        _addressRepository = addressRepository;
    }

    public async Task CreateAddressForUser(int userId)
    {
        await _addressRepository.CreateAddressAsync(userId);
    }

    public async Task<Address> GetAddressByUser(int userId)
    {
        return await _addressRepository.GetAddressByUserIdAsync(userId);
    }

    public async Task UpdateAddress(Address address, int userId)
    {
        var addressToUpdate = await GetAddressByUser(userId);

        addressToUpdate.Street = address.Street;
        addressToUpdate.Number = address.Number;
        addressToUpdate.Complement = address.Complement;
        addressToUpdate.Neighborhood = address.Neighborhood;
        addressToUpdate.City = address.City;
        addressToUpdate.PostalCode = address.PostalCode;

        await _addressRepository.UpdateAddressAsync(addressToUpdate);
        
    }
}
