using Api;
using Api.Models.Requests;
using Api.Utils;
using Data.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace ToDoListAPI.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class ItemController : ExtendedControllerBase
{
    private const int PAGINATION_COUNT = 10;
    private const string PAGINATION_INDEX_KEY = nameof(PAGINATION_INDEX_KEY); 

    private readonly CurrentUser _currentUser;
    private readonly IItemService _itemService;

    public ItemController(CurrentUser currentUser, IItemService itemService)
    {
        _currentUser = currentUser;
        _itemService = itemService;
    }

    [HttpGet("test")]
    public IActionResult Get()
    {
        return Ok($"{nameof(AuthenticationController)} is working properly!");
    }

    [HttpGet("all/{isRefresh?}")]
    public async Task<IActionResult> GetListsOfUserByPagination(RegisterRequestModel request)
    {
        var skip = HttpContext.Session.GetInt32(PAGINATION_INDEX_KEY) ?? 0;

        //var response = await _itemService.GetActivitiesAsync(PAGINATION_COUNT, skip);

        skip += PAGINATION_COUNT;

        HttpContext.Session.SetInt32(PAGINATION_INDEX_KEY, skip);

        //return HandleServiceResponse(response);
        //var b = DateTimeOffset.UtcNow;
        //b.ToOffset(TimeSpan.Zero);
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
