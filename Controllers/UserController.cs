using eApp.Models;
using eApp.Services;
using eApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace eApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : Controller
{
    private readonly IUserService _userService;
    private readonly TokenService _tokenService;

    public UserController(IUserService userService, TokenService tokenService)
    {
        _userService = userService;
        _tokenService = tokenService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        try
        {
            return Ok(await _userService.GetAllUsersAsync());
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpGet("profile")]
    [Authorize]
    public async Task<ActionResult<User>> GetUserById()
    {
        try
        {
            var userId = User.FindFirst("id")?.Value;
            return Ok(await _userService.GetUserDetailsAsync(int.Parse(userId)));
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult> PostUser(User user)
    {
        try
        {
            var userToCreate = await _userService.CreateUserAsync(user);
            var token = _tokenService.GenerateJwtToken(userToCreate.Id);
            return Ok(new { token });
        }
        catch (ArgumentNullException e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("login")]
    public async Task<ActionResult> LoginUser(User user)
    {
        try
        {
            var userToLogin = await _userService.LoginUserAsync(user);
            var token = _tokenService.GenerateJwtToken(userToLogin.Id);
            return Ok(new { token });
        }
        catch (UnauthorizedAccessException e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut]
    [Authorize]
    public async Task<ActionResult> PutUser(User user)
    {
        try
        {
            var userId = User.FindFirst("id")?.Value;
            await _userService.UpdateUserAsync(user, int.Parse(userId));
            return Ok(new { message = "Usuário Atualizado" });
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpDelete("{userId}")]
    public async Task<ActionResult> DeleteUser(int userId)
    {
        try
        {
            await _userService.DeleteUserAsync(userId);
            return Ok("Usuário Deletado");
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}
