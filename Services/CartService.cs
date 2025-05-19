using System.Globalization;
using eApp.Models;
using eApp.Repositories.Interfaces;
using eApp.Services.Interfaces;

namespace eApp.Services;

public class CartService : ICartService
{
    private readonly ICartRepository _cartRepository;
    private readonly IProductService _productService;

    public CartService(ICartRepository cartRepository, IProductService productService)
    {
        _cartRepository = cartRepository;
        _productService = productService;
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
        var cart = await _cartRepository.GetCartByUserIdAsync(userId);
        var product = await _productService.GetProductByIdAsync(productId);

        var itemExists = cart.CartItems.FirstOrDefault(cartItem => cartItem.ProductId == productId);

        if (itemExists != null)
        {
            itemExists.Quantity++;
        }
        else
        {
            cart.CartItems.Add(
                new CartItem
                {
                    ProductId = productId,
                    CartId = cart.Id,
                    Quantity = 1,
                    Price = product.Price,
                    Offer = product.Offer,
                }
            );
        }

        cart.TotalPrice = cart.CartItems.Sum(cartItem => cartItem.Quantity * cartItem.Price);
    
        await _cartRepository.UpdateAsync(cart);
    }

    public async Task RemoveProductFromCartAsync(int userId, int productId)
    {
        await _cartRepository.RemoveProductAsync(userId, productId);
    }

    

    public async Task CreateCartForUser(int userId)
    {
        await _cartRepository.CreateCartAsync(userId);
    }

    public CartDTO GetCartSummary(Cart cart)
    {
        var total = cart.CartItems.Sum(cartItem => cartItem.Quantity * cartItem.Price);
        var totalWithDiscount = cart.CartItems.Sum(cartItem => cartItem.Price * (1 - (cartItem.Offer / 100m)) * cartItem.Quantity);
        var totalDiscountAmount = total - totalWithDiscount;
        var discountPercentageAmount = totalDiscountAmount / total * 100;
        return new CartDTO
        {
            CartItems = cart.CartItems,
            TotalBRL = total.ToString("C", new CultureInfo("pt-BR")),
            TotalWithDiscountBRL = totalWithDiscount.ToString("C", new CultureInfo("pt-BR")),
            TotalDiscountAmountBRL = totalDiscountAmount.ToString("C", new CultureInfo("pt-BR")),
            DiscountPercentageAmount = discountPercentageAmount.ToString("F1"),
        };
    }
}
