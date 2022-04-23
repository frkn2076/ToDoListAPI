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

    //[HttpGet("test")]
    //public IActionResult Get()
    //{
    //    return Ok($"{nameof(ItemController)} is working properly!");
    //}

    //[HttpPost("all")]
    //public async Task<IActionResult> GetListsOfUserByPagination(ListPaginationFilterRequestModel request)
    //{
    //    var skip = HttpContext.Session.GetInt32(PAGINATION_INDEX_KEY) ?? 0;

    //    //var response = await _itemService.GetActivitiesAsync(PAGINATION_COUNT, skip);

    //    skip += PAGINATION_COUNT;

    //    HttpContext.Session.SetInt32(PAGINATION_INDEX_KEY, skip);

    //    //return HandleServiceResponse(response);
    //    //var b = DateTimeOffset.UtcNow;
    //    //b.ToOffset(TimeSpan.Zero);
    //    return Ok();
    //}

    [HttpPost("list")]
    public async Task<IActionResult> CreateList(ListRequestModel request)
    {
        var requestDTO = request.Adapt<ListRequestDTO>();
        var response = await _itemService.CreateListAsync(requestDTO, _currentUser.Id);
        return HandleServiceResponse(response);
    }

    [HttpPut("list/{id}")]
    public async Task<IActionResult> UpdateList(ListRequestModel request, int id)
    {
        var requestDTO = request.Adapt<ListRequestDTO>();
        requestDTO.Id = id;
        var response = await _itemService.UpdateListAsync(requestDTO);
        return HandleServiceResponse(response);
    }

    [HttpDelete("list/{id}")]
    public async Task<IActionResult> DeleteList(int id)
    {
        var response = await _itemService.DeleteListAsync(id);
        return HandleServiceResponse(response);
    }

    [HttpPost("task")]
    public async Task<IActionResult> CreateTask(TaskRequestModel request)
    {
        var requestDTO = request.Adapt<TaskRequestDTO>();
        var response = await _itemService.CreateTaskAsync(requestDTO);
        return HandleServiceResponse(response);
    }

    [HttpPut("task/{id}")]
    public async Task<IActionResult> UpdateTask(TaskRequestModel request, int id)
    {
        var requestDTO = request.Adapt<TaskRequestDTO>();
        requestDTO.Id = id;
        var response = await _itemService.UpdateTaskAsync(requestDTO);
        return HandleServiceResponse(response);
    }

    [HttpDelete("task/{id}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        var response = await _itemService.DeleteTaskAsync(id);
        return HandleServiceResponse(response);
    }
}
