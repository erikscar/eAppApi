using eApp.Models;

namespace eApp.Repositories.Interfaces;

public interface ICartRepository
{
    Task CreateCartAsync(int userId);
    Task<Cart> GetCartByUserIdAsync(int userId);
    Task UpdateAsync(Cart cart);
    Task RemoveProductAsync(int userId, int productId);
}