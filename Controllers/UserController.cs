using Microsoft.AspNetCore.Mvc;
using Npgsql.Replication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

public class CreateUserDto
{
    public string Email { get; set; } = "";
    public string Password { get; set; } = "";
}

public class UserDto
{
    public string Id { get; set; }
    public string? Email { get; set; }

    public UserDto(User user)
    {
        this.Id = user.Id;
        this.Email = user.Email;
    }
}


[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    public UserController(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    [HttpPost]
    [Route("create_user")]
    public async Task<IActionResult> CreateUser([FromForm] CreateUserDto dto)
    {
        if (ModelState.IsValid)
        {
            var user = new User { UserName = dto.Email, Email = dto.Email };
            var result = await _userManager.CreateAsync(user, dto.Password);

            if (result.Succeeded)
            {
                return Ok(new UserDto(user));
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return BadRequest(ModelState);
            }
        }
        else
        {
            return BadRequest(ModelState);
        }
    }

    [HttpGet("get_all_users")]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userManager.Users.ToListAsync();
        var userDtos = users.Select(user => new UserDto(user)).ToList();
        return Ok(userDtos);
    }
}
