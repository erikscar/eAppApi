using eApp.Data;
using eApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : Controller
{
    private readonly EAppContext _context;
    public UserController(EAppContext context) {
        _context = context;

    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        var users = await _context.Users.ToListAsync();
        
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUserById(int id)
    {
        var user = await _context.Users.FindAsync(id);

        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult> PostUser(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return Ok("Usuário Cadastrado");
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> PutUser(int id, User user)
    {
        if(id != user.Id)
        {
            return BadRequest("Usuário Não Encontrado");
        }

        _context.Entry(user).State = EntityState.Modified;

        await _context.SaveChangesAsync();

        return Ok("Usuário Atualizado");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        User userToDelete = await _context.Users.FindAsync(id);

        if(userToDelete == null) {
            return NotFound();
        }

        _context.Users.Remove(userToDelete);
        await _context.SaveChangesAsync();

        return Ok("Usuário Deletado");
    }

}