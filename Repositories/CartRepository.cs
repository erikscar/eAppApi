using eApp.Data;
using eApp.Data.Mappings;
using eApp.Models;
using eApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eApp.Repositories;

public class CartRepository : ICartRepository
{
    private readonly EAppContext _context;

    public CartRepository(EAppContext context)
    {
        _context = context;
    }

    public async Task<Cart> GetCartByUserIdAsync(int userId)
    {
        return await _context
            .Carts.Include(cart => cart.CartItems)
            .ThenInclude(cartItem => cartItem.Product)
            .FirstOrDefaultAsync(cart => cart.UserId == userId);
    }

    public async Task RemoveProductAsync(int userId, int productId)
    {
        var cart = await GetCartByUserIdAsync(userId);
        var product = cart.CartItems.FirstOrDefault(p => p.Id == productId);

        cart.CartItems.Remove(product);

        await _context.SaveChangesAsync();
    }

    public async Task CreateCartAsync(int userId)
    {
        var cart = new Cart { UserId = userId, CartItems = new List<CartItem>() };

        await _context.Carts.AddAsync(cart);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Cart cart)
    {
        _context.Carts.Update(cart);
        await _context.SaveChangesAsync();
    }
}
