using Service.Models;
using Service.Models.Requests;
using Service.Models.Responses;

namespace Service.Contracts;

public interface IItemService
{
    Task<ServiceResponse<ListResponseDTO>> CreateListAsync(ListRequestDTO model, int profileId);

    Task<ServiceResponse> UpdateListAsync(ListRequestDTO model);

    Task<ServiceResponse> DeleteListAsync(int id);

    Task<ServiceResponse<TaskResponseDTO>> CreateTaskAsync(TaskRequestDTO model);

    Task<ServiceResponse> UpdateTaskAsync(TaskRequestDTO model);

    Task<ServiceResponse> DeleteTaskAsync(int id);

    Task<ServiceResponse> UpdateTaskStatusAsync(bool isDone, int id);

    Task<ServiceResponse> UpdateUserTimeZoneAsync(int timeZone, int profileId);

    Task<ServiceResponse<IEnumerable<ListResponseDTO>>> GetListsOfUserAsync(ListPaginationFilterRequestDTO model, int timeZone);
}
