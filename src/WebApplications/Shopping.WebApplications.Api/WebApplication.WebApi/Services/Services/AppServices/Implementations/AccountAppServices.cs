using Shopping.WebApi.Entities;
using Microsoft.AspNetCore.Identity;
using Shopping.WebApi.Services.Services.Services.Contracts;
using Shopping.WebApi.Services.Services.AppServices.Contracts;

namespace Shopping.WebApi.Services.Services.AppServices.Implementations;
public class AccountAppServices : IAccountAppServices
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IAccountServices _userServices;

    public AccountAppServices(UserManager<IdentityUser> userManager, IAccountServices userServices)
    {
        _userManager = userManager;
        _userServices = userServices;
    }

    public async Task Register(RegisterDto registerDto)
    {
        var user = new IdentityUser()
        {
            Email = registerDto.Email,
            UserName = registerDto.Email
        };

        await _userManager.CreateAsync(user, registerDto.Password);

        await _userManager.AddToRoleAsync(user, "User");
    }


    public async Task<string> Login(LoginInputModel model)
        => await _userServices.GenerateToken(model.UserName, model.Password);

    public async Task<string> GenerateToken(string username, string password)
        => await _userServices.GenerateToken(username, password);
}