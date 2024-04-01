namespace Shopping.WebApi.Services.Services.Services.Contracts;

public interface IAccountServices
{
    Task<string> GenerateToken(string username, string password);
    Task<bool> UserExists(string username, string password);
}
