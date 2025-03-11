using Microsoft.AspNetCore.Mvc;
using OpenableProject.DTO;
using OpenableProject.Services;

namespace OpenableProject.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController: ControllerBase
{
    private readonly AuthService _authService = new();

    [HttpPost("login")]
    public IActionResult Login([FromBody] UserLoginDto loginDto)
    {
        var token = _authService.Authenticate(loginDto.Username, loginDto.Password);
        if (token == null)
            return Unauthorized(new { message = "Invalid username or password" });

        return Ok(new { Token = token });
    }
    
}