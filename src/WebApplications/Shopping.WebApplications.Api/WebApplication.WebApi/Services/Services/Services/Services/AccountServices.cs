using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Shopping.WebApi.Services.Services.Services.Contracts;

namespace Shopping.WebApi.Services.Services.Services.Services;
public class AccountServices : IAccountServices
{
    private readonly IConfiguration _configuration;
    private readonly UserManager<IdentityUser> _userManager;

    public AccountServices(IConfiguration configuration, UserManager<IdentityUser> userManager)
    {
        _configuration = configuration;
        _userManager = userManager;
    }

    public async Task<string> GenerateToken(string username, string password)
    {
        if (!await UserExists(username, password)) return null;

        var secretKey = _configuration.GetSection("JWTSetting").GetSection("securityKey").Value;

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(secretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer: _configuration.GetSection("JWTSetting").GetSection("ValidIssuer").Value,
            audience: _configuration.GetSection("JWTSetting").GetSection("ValidAudience").Value,
            claims: new[] { new Claim(ClaimTypes.Name, username) },
            expires: DateTime.Now.AddDays(30),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    public async Task<bool> UserExists(string username, string password)
    {
        var user = await _userManager.FindByNameAsync(username);
        return user != null && await _userManager.CheckPasswordAsync(user, password);
    }

}
