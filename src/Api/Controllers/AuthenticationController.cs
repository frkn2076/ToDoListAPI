using Api.Models.Requests;
using Api.Utils;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Service.Models.Requests;

namespace ToDoListAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticationController : ExtendedControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpGet("test")]
    public IActionResult Get()
    {
        return Ok($"{nameof(AuthenticationController)} is working properly!");
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(RegisterRequestModel request)
    {
        var requestDTO = request.Adapt<AuthenticationRequestDTO>();
        var response = await _authenticationService.RegisterAsync(requestDTO);
        return HandleServiceResponse(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(RegisterRequestModel request)
    {
        var requestDTO = request.Adapt<AuthenticationRequestDTO>();
        var response = await _authenticationService.LoginAsync(requestDTO);
        return HandleServiceResponse(response);
    }
}
