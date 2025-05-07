using eApp.Models;

namespace eApp.Repositories.Interfaces;

public interface ICartRepository
{
    Task<Cart> GetCartByUserIdAsync(int userId);
    Task AddProductAsync(int userId, int productId);
    Task RemoveProductAsync(int userId, int productId);
}