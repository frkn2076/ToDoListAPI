using Data;
using Data.Contracts;
using Data.Entities;
using Data.Models;
using Mapster;
using Service.Contracts;
using Service.Models;
using Service.Models.Requests;
using Service.Models.Responses;

namespace Service.Implementations;

public class ItemService : IItemService
{
    private readonly IRepository _repository;

    public ItemService(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<ServiceResponse<ListResponseDTO>> CreateListAsync(ListRequestDTO model, int profileId)
    {
        ArgumentNullException.ThrowIfNull(model);

        var list = model.Adapt<ListEntity>();
        list.ProfileId = profileId;

        var createdList = await _repository.CreateListAsync(list);

        if (createdList == null)
        {
            return ServiceResponse<ListResponseDTO>.Failure(ErrorMessages.OperationHasFailed);
        }

        var response = createdList.Adapt<ListResponseDTO>();

        return ServiceResponse<ListResponseDTO>.Success(response);
    }

    public async Task<ServiceResponse> UpdateListAsync(ListRequestDTO model)
    {
        ArgumentNullException.ThrowIfNull(model);

        var list = model.Adapt<ListEntity>();

        var isSuccessful = await _repository.UpdateListAsync(list);

        if (!isSuccessful)
        {
            return ServiceResponse.Failure(ErrorMessages.OperationHasFailed);
        }

        return ServiceResponse.Success();
    }

    public async Task<ServiceResponse> DeleteListAsync(int id)
    {
        var isSuccessful = await _repository.DeleteListAsync(id);

        if (!isSuccessful)
        {
            return ServiceResponse.Failure(ErrorMessages.OperationHasFailed);
        }

        return ServiceResponse.Success();
    }

    public async Task<ServiceResponse<TaskResponseDTO>> CreateTaskAsync(TaskRequestDTO model)
    {
        ArgumentNullException.ThrowIfNull(model);

        var task = model.Adapt<TaskEntity>();

        var createdTask = await _repository.CreateTaskAsync(task);

        if (createdTask == null)
        {
            return ServiceResponse<TaskResponseDTO>.Failure(ErrorMessages.OperationHasFailed);
        }

        var response = createdTask.Adapt<TaskResponseDTO>();

        return ServiceResponse<TaskResponseDTO>.Success(response);
    }

    public async Task<ServiceResponse> UpdateTaskAsync(TaskRequestDTO model)
    {
        ArgumentNullException.ThrowIfNull(model);

        var task = model.Adapt<TaskEntity>();

        var isSuccessful = await _repository.UpdateTaskAsync(task);

        if (!isSuccessful)
        {
            return ServiceResponse.Failure(ErrorMessages.OperationHasFailed);
        }

        return ServiceResponse.Success();
    }

    public async Task<ServiceResponse> DeleteTaskAsync(int id)
    {
        var isSuccessful = await _repository.DeleteTaskAsync(id);

        if (!isSuccessful)
        {
            return ServiceResponse.Failure(ErrorMessages.OperationHasFailed);
        }

        return ServiceResponse.Success();
    }

    public async Task<ServiceResponse> UpdateTaskStatusAsync(bool isDone, int id)
    {
        var isSuccessful = await _repository.UpdateTaskStatusAsync(isDone, id);

        if (!isSuccessful)
        {
            return ServiceResponse.Failure(ErrorMessages.OperationHasFailed);
        }

        return ServiceResponse.Success();
    }

    public async Task<ServiceResponse> UpdateUserTimeZoneAsync(int timeZone, int profileId)
    {
        var isSuccessful = await _repository.UpdateUserTimeZoneAsync(timeZone, profileId);

        if (!isSuccessful)
        {
            return ServiceResponse.Failure(ErrorMessages.OperationHasFailed);
        }

        return ServiceResponse.Success();
    }

    public async Task<ServiceResponse<IEnumerable<ListResponseDTO>>> GetListsOfUserAsync(ListPaginationFilterRequestDTO model, int profileId)
    {
        ArgumentNullException.ThrowIfNull(model);

        var filter = model.Adapt<ListPaginationFilter>();

        var lists = await _repository.GetListsOfUserAsync(filter);

        if (lists == null || !lists.Any())
        {
            return ServiceResponse<IEnumerable<ListResponseDTO>>.Failure(ErrorMessages.NoRecordHasFound);
        }

        var timeZone = await _repository.GetTimeZoneByIdAsync(profileId);

        var response = lists.Select(x => new ListResponseDTO()
        {
            Id = x.Id,
            Title = x.Title,
            Description = x.Description,
            Date = x.Date.ToOffset(new TimeSpan(timeZone, 0, 0))
        });

        return ServiceResponse<IEnumerable<ListResponseDTO>>.Success(response);
    }

    public async Task<ServiceResponse<IEnumerable<TaskResponseDTO>>> GetTasksOfListAsync(TaskFilterRequestDTO model, int timeZone)
    {
        ArgumentNullException.ThrowIfNull(model);

        var filter = model.Adapt<TaskFilter>();

        var tasks = await _repository.GetTasksOfListAsync(filter);

        if (tasks == null || !tasks.Any())
        {
            return ServiceResponse<IEnumerable<TaskResponseDTO>>.Failure(ErrorMessages.NoRecordHasFound);
        }

        var response = tasks.Select(x => new TaskResponseDTO()
        {
            Id = x.Id,
            Title = x.Title,
            Description = x.Description,
            Deadline = x.Deadline.ToOffset(new TimeSpan(timeZone, 0, 0))
        });

        return ServiceResponse<IEnumerable<TaskResponseDTO>>.Success(response);
    }
}
