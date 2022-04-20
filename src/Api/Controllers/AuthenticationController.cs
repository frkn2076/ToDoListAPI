using Api;
using Api.Models.Requests;
using Api.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace ToDoListAPI.Controllers;

[ApiController]
[Route("[controller]")]
//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class AuthenticationController : ExtendedControllerBase
{
    private readonly CurrentUser _currentUser;
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(CurrentUser currentUser, IAuthenticationService authenticationService)
    {
        _currentUser = currentUser;
        _authenticationService = authenticationService;
    }

    [HttpGet("test")]
    public IActionResult Get()
    {
        return Ok($"{nameof(AuthenticationController)} is working properly!");
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequestModel request)
    {
        //var response = await _authenticationService.Register(request.UserName, request.Password);
        //return HandleServiceResponse(response);
        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(RegisterRequestModel request)
    {
        //var response = await _authenticationService.Login(request.UserName, request.Password);
        //return HandleServiceResponse(response);
        return Ok();
    }
}
