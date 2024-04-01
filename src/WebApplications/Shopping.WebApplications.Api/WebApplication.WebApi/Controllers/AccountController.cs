using Microsoft.AspNetCore.Mvc;
using Shopping.WebApi.Entities;
using Shopping.WebApi.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Shopping.WebApi.Services.Services.AppServices.Contracts;

namespace Shopping.WebApi.Controllers;

[ApiResultFilter]
public class AccountController : ControllerBase
{

    private readonly IAccountAppServices _accountAppServices;

    public AccountController(IAccountAppServices accountAppServices)
    {
        _accountAppServices = accountAppServices;
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<ActionResult> Register(RegisterDto registerDto)
    {
        await _accountAppServices.Register(registerDto);
        return Ok();
    }


    [AllowAnonymous]
    [HttpGet("Login")]
    public async Task<ActionResult<LoginOutputModel>> Login(LoginInputModel model)
        => Ok(await _accountAppServices.GenerateToken(model.UserName, model.Password));

    [HttpGet("validToken")]
    public async Task<ActionResult<validTokenModel>> ValidToken()
        => Ok(User.Identity.Name);

}