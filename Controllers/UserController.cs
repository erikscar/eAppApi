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
    public UserController(IUserRepository userRepository) {
        _userRepository = userRepository;

    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        var users = await _userRepository.GetAllUsers();

         if(users == null )
        {
            return NotFound("Nenhum Usuário Encontrado");
        }
        
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUserById(int id)
    {
        var user = await _userRepository.GetUserById(id);

        if(user == null)
        {
            return NotFound("Usuário Não Encontrado");
        }

        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult> PostUser(User user)
    {
        await _userRepository.CreateUser(user);
        await _userRepository.Save();

        return Ok("Usuário Cadastrado");
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> PutUser(int id, User user)
    {
        if(id != user.Id)
        {
            return NotFound("Usuário Não Encontrado");
        }

       _userRepository.UpdateUser(user);

        await _userRepository.Save();

        return Ok("Usuário Atualizado");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        User userToDelete = await _userRepository.GetUserById(id);

        if(userToDelete == null) {
            return NotFound("Usuário Não Encontrado");
        }

        await _userRepository.DeleteUser(userToDelete);
        await _userRepository.Save();

        return Ok("Usuário Deletado");
    }

}