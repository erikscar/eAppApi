using eApp.Models;

namespace eApp.Services.Interfaces;

public interface ICartService
{
    Task CreateCartForUser(int userId);
    Task<Cart> GetCartByUserIdAsync(int userid);
    CartDTO GetCartSummary(Cart cart);
    Task AddProductToCartAsync(int userId, int productId);
    Task RemoveProductFromCartAsync(int userId, int productId);
}