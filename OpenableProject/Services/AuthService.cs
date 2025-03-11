using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using OpenableProject.Enums;

namespace OpenableProject.Services;

public class AuthService
{
    private const string SecretKey = "ThisIsASecretKeyForJwtThisIsASecretKeyForJwt"; // 需更換成更安全的密鑰
    private static readonly Dictionary<string, (string Password, UserRole Role, int? RestaurantId)> Users = new()
    {
        { "admin", ("admin123", UserRole.Admin, null) },
        { "restaurantA", ("passwordA", UserRole.Restaurant, 1) },
        { "restaurantB", ("passwordB", UserRole.Restaurant, 2) },
        { "customer1", ("cust123", UserRole.Customer, null) }
    };

    public string Authenticate(string username, string password)
    {
        if (!Users.ContainsKey(username) || Users[username].Password != password)
            return null;

        var user = Users[username];

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, user.Role.ToString())
        };

        if (user.RestaurantId.HasValue)
            claims.Add(new Claim("RestaurantId", user.RestaurantId.Value.ToString()));

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: "OpenableProject",
            audience: "OpenableUsers",
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}