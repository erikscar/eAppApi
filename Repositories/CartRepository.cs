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
        return await _context.Carts.Include(cart => cart.Products).FirstOrDefaultAsync(cart => cart.UserId == userId);
    }

    public async Task AddProductAsync(int userId, int productId)
    {
        var cart = await GetCartByUserIdAsync(userId);
        var product = await _context.Products.FindAsync(productId);

        cart.Products.Add(product);

        await _context.SaveChangesAsync();
    }

    public async Task RemoveProductAsync(int userId, int productId)
    {
        var cart = await GetCartByUserIdAsync(userId);
        var product = await _context.Products.FindAsync(productId);

        cart.Products.Remove(product);

        await _context.SaveChangesAsync();

    }

    public async Task CreateCartAsync(int userId)
    {
        var cart = new Cart{ UserId = userId, Products = new List<Product>() };

        await _context.Carts.AddAsync(cart);
        await _context.SaveChangesAsync();
    }
}
