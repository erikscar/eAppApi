using eApp.Models;

namespace eApp.Services.Interfaces;

public interface ICartService
{
    Task<Cart> GetCartByUserIdAsync(int userid);
    Task AddProductToCartAsync(int userId, int productId);
    Task RemoveProductFromCartAsync(int userId, int productId);
}