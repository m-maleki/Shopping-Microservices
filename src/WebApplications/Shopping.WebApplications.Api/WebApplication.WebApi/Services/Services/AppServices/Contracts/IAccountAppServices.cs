using Shopping.WebApi.Entities;

namespace Shopping.WebApi.Services.Services.AppServices.Contracts;
public interface IAccountAppServices
{
    Task Register(RegisterDto registerDto);
    Task<string> Login(LoginInputModel model);
    Task<string> GenerateToken(string username, string password);
}