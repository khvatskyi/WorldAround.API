using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WorldAround.Application.Interfaces.Application;
using WorldAround.Domain.Entities;

namespace WorldAround.Application.Helpers;

public class JwtTokenHelper : IJwtTokenHelper
{
    private readonly IConfiguration _configuration;

    public JwtTokenHelper(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateJwtAccessToken(User user, IList<string> roles)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new("id", user.Id.ToString()),
            new(JwtRegisteredClaimNames.UniqueName, user.UserName),
            new(JwtRegisteredClaimNames.Email, user.Email),
        };

        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        return GenerateJwtToken(claims);
    }

    private string GenerateJwtToken(IEnumerable<Claim> claims)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTConfiguration:JwtKey"]));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["JWTConfiguration:JwtExpireDays"]));

        var token = new JwtSecurityToken(
            issuer: _configuration["JWTConfiguration:JwtIssuer"],
            audience: _configuration["JWTConfiguration:JwtAudience"],
            claims: claims,
            expires: expires,
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
