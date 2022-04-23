using Service.Models;
using Service.Models.Requests;
using Service.Models.Responses;

namespace Service.Contracts;

public interface IAuthenticationService
{
    Task<ServiceResponse<AuthenticationResponseModel>> Register(AuthenticationRequestDTO model);

    Task<ServiceResponse<AuthenticationResponseModel>> Login(AuthenticationRequestDTO model);
}
