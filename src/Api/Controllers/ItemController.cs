using Api;
using Api.Models.Requests;
using Api.Utils;
using Data.Entities;
using Mapster;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Service.Models.Requests;

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

    [AllowAnonymous]
    [HttpGet("test")]
    public IActionResult Get()
    {
        return Ok($"{nameof(ItemController)} is working properly!");
    }

    [HttpPost("list")]
    public async Task<IActionResult> CreateListAsync(ListRequestModel request)
    {
        var requestDTO = request.Adapt<ListRequestDTO>();
        var response = await _itemService.CreateListAsync(requestDTO, _currentUser.Id);
        return HandleServiceResponse(response);
    }

    [HttpPut("list/{id}")]
    public async Task<IActionResult> UpdateListAsync(ListRequestModel request, int id)
    {
        var requestDTO = request.Adapt<ListRequestDTO>();
        requestDTO.Id = id;
        var response = await _itemService.UpdateListAsync(requestDTO);
        return HandleServiceResponse(response);
    }

    [HttpDelete("list/{id}")]
    public async Task<IActionResult> DeleteListAsync(int id)
    {
        var response = await _itemService.DeleteListAsync(id);
        return HandleServiceResponse(response);
    }

    [HttpPost("task")]
    public async Task<IActionResult> CreateTaskAsync(TaskRequestModel request)
    {
        var requestDTO = request.Adapt<TaskRequestDTO>();
        var response = await _itemService.CreateTaskAsync(requestDTO);
        return HandleServiceResponse(response);
    }

    [HttpPut("task/{id}")]
    public async Task<IActionResult> UpdateTaskAsync(TaskRequestModel request, int id)
    {
        var requestDTO = request.Adapt<TaskRequestDTO>();
        requestDTO.Id = id;
        var response = await _itemService.UpdateTaskAsync(requestDTO);
        return HandleServiceResponse(response);
    }

    [HttpDelete("task/{id}")]
    public async Task<IActionResult> DeleteTaskAsync(int id)
    {
        var response = await _itemService.DeleteTaskAsync(id);
        return HandleServiceResponse(response);
    }

    [HttpPut("task/status/{id}")]
    public async Task<IActionResult> UpdateTaskStatusAsync(TaskStatusRequestModel request, int id)
    {
        var response = await _itemService.UpdateTaskStatusAsync(request.IsDone, id);
        return HandleServiceResponse(response);
    }

    [HttpPut("user/timezone")]
    public async Task<IActionResult> UpdateUserTimeZoneAsync(UserTimeZoneRequestModel request)
    {
        var response = await _itemService.UpdateUserTimeZoneAsync(request.TimeZone, _currentUser.Id);
        return HandleServiceResponse(response);
    }

    [HttpPost("list/all")]
    public async Task<IActionResult> GetListsOfUserByPagination(ListPaginationFilterRequestModel request)
    {
        int skip = 0;

        if (!request.IsRefresh)
        {
            skip = HttpContext.Session.GetInt32(PAGINATION_INDEX_KEY) ?? 0;
        }

        var requestDTO = request.Adapt<ListPaginationFilterRequestDTO>();
        requestDTO.Skip = skip;
        requestDTO.Count = PAGINATION_COUNT;
        requestDTO.ProfileId = _currentUser.Id;

        var response = await _itemService.GetListsOfUserAsync(requestDTO, _currentUser.TimeZone);

        skip += PAGINATION_COUNT;
        HttpContext.Session.SetInt32(PAGINATION_INDEX_KEY, skip);

        return HandleServiceResponse(response);
    }

}
