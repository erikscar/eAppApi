using eApp.Models;
using eApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AddressController : Controller
{
    private readonly IAddressService _addressService;

    public AddressController(IAddressService addressService)
    {
        _addressService = addressService;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAddress()
    {
        int userId = int.Parse(User.FindFirst("id")?.Value);
        return Ok(await _addressService.GetAddressByUser(userId));
    }

    [HttpPut]
    [Authorize]
    public async Task<IActionResult> UpdateAddress(Address address)
    {
        var userId = User.FindFirst("id")?.Value;
        await _addressService.UpdateAddress(address, int.Parse(userId));
        return Ok(new { message = "Usuário Atualizado" });
    }
}
