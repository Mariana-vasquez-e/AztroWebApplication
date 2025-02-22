using AztroWebApplication.Models;
using AztroWebApplication.Data;
using AztroWebApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace AztroWebApplication.Controllers;

[ApiController]
[Route("api/[controller]")]


public class UserController : ControllerBase
{
    private readonly UserService userService;

    public UserController(ApplicationDbContext context)
    {
        userService = new UserService(context);
    }

    // Metodo para obtener todos los usuarios
    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await userService.GetAllUsers();
        return Ok(users);
    }

    // Metodo para obtener un usuario por su id
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await userService.GetUserById(id);
        if (user == null)
        {
            return NotFound(new ErrorResponse { Message = "User not found", StatusCode = 404 });
        }

        return Ok(user);
    }

    // Metodo para crear un usuario
    [HttpPost]
    public async Task<IActionResult> CreateUser(User user)
    {
        var createdUser = await userService.CreateUser(user);
        if (createdUser == null)
        {
            return BadRequest(new ErrorResponse { Message = "User must be between 18 and 80 years old", StatusCode = 400 });
        }
        return Created(nameof(GetUserById), createdUser);
    }

    // Metodo para actualizar un usuario por su id
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUserById(int id, User user)
    {
        await userService.UpdateUserById(id, user);
        return Ok(user);
    }

    // Metodo para eliminar un usuario por su id
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUserById(int id)
    {
        var userRemoved = await userService.DeleteUserById(id);
        if (userRemoved == null)
        {
            return NotFound(new ErrorResponse { Message = "User not found", StatusCode = 404 });
        }
        return Ok(new { Message = "User deleted", User = userRemoved });
    }
}
