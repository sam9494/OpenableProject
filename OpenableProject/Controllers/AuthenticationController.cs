using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OpenableProject.Services;

namespace OpenableProject.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly IUserInfoService _userService; // 假設有一個用戶服務來處理用戶資料

    public AuthenticationController(IConfiguration configuration, IUserInfoService userService)
    {
        _configuration = configuration;
        _userService = userService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] UserLoginDto userLogin)
    {
        var user = _userService.Authenticate(userLogin.UserName, userLogin.Password);
        if (user == null)
        {
            return Unauthorized();
        }

        var token = GenerateJwtToken(user);
        return Ok(new { Token = token });
    }
    //
    // [HttpGet("exception")]
    // public IActionResult Exception()
    // {
    //     return Ok();
    // }
    //
    // [HttpGet("not-exist-exception")]
    // public IActionResult NotExistException()
    // {
    //     return Ok();
    // }

    private string GenerateJwtToken(UserInfo user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("RestaurantId", user.RestaurantId.ToString())
        };

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddHours(3),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

public class UserLoginDto
{
    public string UserName { get; set; }
    public string Password { get; set; }
}
