using Service.Models;
using Service.Models.Requests;
using Service.Models.Responses;

namespace Service.Contracts;

public interface IItemService
{
    Task<ServiceResponse<ListResponseDTO>> CreateListAsync(ListRequestDTO model, int profileId);

    Task<ServiceResponse> UpdateListAsync(ListRequestDTO model);
}
