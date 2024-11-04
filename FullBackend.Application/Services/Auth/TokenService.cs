using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FullBackend.Application.Services.Helpers;
using FullBackend.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace FullBackend.Application.Services.Auth;

public class TokenService
{
    private ClaimsIdentity GenerateClaims(User user)
    {
        var claims = new ClaimsIdentity(new[]
            {
                new Claim("id", user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email)
            }.Concat(user.Roles.Select(r => new Claim(ClaimTypes.Role, r)))
        );
        return claims;
    } 
    
    public string GenerateToken(User user)
    {
        var handler = new JwtSecurityTokenHandler(); // to create or validate JWT
        var key = Encoding.ASCII.GetBytes(AuthSettings.PrivateKey);
        var credentials = new SigningCredentials( // Token Signature
            new SymmetricSecurityKey(key), 
            SecurityAlgorithms.HmacSha256Signature);

        // Token Informations
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = GenerateClaims(user), // Payload ( User information ) 
            Expires = DateTime.UtcNow.AddHours(1), // Expiration
            SigningCredentials = credentials // Signature
        };

        var token = handler.CreateToken(tokenDescriptor);
        return handler.WriteToken(token); // Serialize token into string format
    }
}