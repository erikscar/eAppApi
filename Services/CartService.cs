using eApp.Models;
using eApp.Repositories.Interfaces;
using eApp.Services.Interfaces;

namespace eApp.Services;

public class CartService : ICartService
{
    private readonly ICartRepository _cartRepository;

    public CartService(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task<Cart> GetCartByUserIdAsync(int userid)
    {
        var cart = await _cartRepository.GetCartByUserIdAsync(userid);

        if (cart == null)
        {
            throw new KeyNotFoundException("Nenhum Carrinho Encontrado");
        }

        return cart;
    }

    public async Task AddProductToCartAsync(int userId, int productId)
    {
        await _cartRepository.AddProductAsync(userId, productId);
    }

    public async Task RemoveProductFromCartAsync(int userId, int productId)
    {
        await _cartRepository.RemoveProductAsync(userId, productId);
    }
}
