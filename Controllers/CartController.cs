using eApp.Models;
using eApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CartController : Controller
{
    private readonly ICartService _cartService;

    public CartController(ICartService cartService)
    {
        _cartService = cartService;
    }

    [HttpGet]
    public async Task<ActionResult<Cart>> GetCart()
    {
        try
        {
            var userId = User.FindFirst("id")?.Value;
            var cart = await _cartService.GetCartByUserIdAsync(int.Parse(userId));

            return Ok(cart);
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost("add")]
    public async Task<ActionResult> AddProduct(int productId)
    {
        var userId = User.FindFirst("id")?.Value;
        await _cartService.AddProductToCartAsync(int.Parse(userId), productId);
        return Ok(new { message = "Produto Adicionado ao Carrinho" });
    }

    [HttpPost("remove")]
    public async Task<ActionResult> RemoveProduct(int productId)
    {
        var userId = User.FindFirst("id")?.Value;
        await _cartService.RemoveProductFromCartAsync(int.Parse(userId), productId);
        return Ok(new { message = "Produto Removido do Carrinho" });
    }
}
