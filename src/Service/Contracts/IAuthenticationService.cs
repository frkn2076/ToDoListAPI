using Service.Models;
using Service.Models.Requests;
using Service.Models.Responses;

namespace Service.Contracts;

public interface IAuthenticationService
{
    Task<ServiceResponse<AuthenticationResponseDTO>> Register(AuthenticationRequestDTO model);

    Task<ServiceResponse<AuthenticationResponseDTO>> Login(AuthenticationRequestDTO model);
}
