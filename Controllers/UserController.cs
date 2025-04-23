using eApp.Models;
using eApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
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

    [HttpGet("{userId}")]
    public async Task<ActionResult<User>> GetUserById(int userId)
    {
        try
        {
            return Ok(await _userService.GetUserDetailsAsync(userId));
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
            await _userService.CreateUserAsync(user);
            return Ok(new { message = "Usuário Cadastrado" });
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
            await _userService.LoginUserAsync(user);
            return Ok("Login Realizado com Sucesso");
        }
        catch (UnauthorizedAccessException e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{userId}")]
    public async Task<ActionResult> PutUser(User user, int userId)
    {
        try
        {
            await _userService.UpdateUserAsync(user, userId);
            return Ok("Usuário Atualizado");
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
