using eApp.Data;
using eApp.Interfaces;
using eApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : Controller
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        var users = await _userRepository.GetAllUsersAsync();

        if (users == null)
        {
            return NotFound("Nenhum Usuário Encontrado");
        }

        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUserById(int id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);

        if (user == null)
        {
            return NotFound("Usuário Não Encontrado");
        }

        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult> PostUser(User user)
    {
        await _userRepository.CreateUserAsync(user);
        await _userRepository.SaveAsync();

        return Ok("Usuário Cadastrado");
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> PutUser(int id, User user)
    {
        if (id != user.Id)
        {
            return NotFound("Usuário Não Encontrado");
        }

        _userRepository.UpdateUser(user);

        await _userRepository.SaveAsync();

        return Ok("Usuário Atualizado");
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUser(int id)
    {
        var userToDelete = await _userRepository.DeleteUserAsync(id);
        await _userRepository.SaveAsync();

        if (!userToDelete)
        {
            return NotFound("Usuário Não Encontrado");
        }

        return Ok("Usuário Deletado");
    }
}
