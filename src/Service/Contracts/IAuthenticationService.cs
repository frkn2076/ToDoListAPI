using Service.Models;
using Service.Models.Requests;
using Service.Models.Responses;

namespace Service.Contracts;

public interface IAuthenticationService
{
    Task<ServiceResponse<AuthenticationResponseDTO>> RegisterAsync(AuthenticationRequestDTO model);

    Task<ServiceResponse<AuthenticationResponseDTO>> LoginAsync(AuthenticationRequestDTO model);
}
