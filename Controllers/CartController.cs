using eApp.Models;
using eApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

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
    [Authorize]
    public async Task<ActionResult<Cart>> GetCart()
    {
        try
        {
            var userId = User.FindFirst("id")?.Value;
            var cart = await _cartService.GetCartByUserIdAsync(int.Parse(userId));
            var cartSummary = _cartService.GetCartSummary(cart);
            return Ok(cartSummary);
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost("add")]
    [Authorize]
    public async Task<ActionResult> AddProduct([FromBody] int productId)
    {
        var userId = User.FindFirst("id")?.Value;
        await _cartService.AddProductToCartAsync(int.Parse(userId), productId);
        return Ok(new { message = "Produto Adicionado ao Carrinho" });
    }

    [HttpPost("remove")]
    [Authorize]
    public async Task<ActionResult> RemoveProduct([FromBody] int productId)
    {
        var userId = User.FindFirst("id")?.Value;
        await _cartService.RemoveProductFromCartAsync(int.Parse(userId), productId);
        return Ok(new { message = "Produto Removido do Carrinho" });
    }
}
