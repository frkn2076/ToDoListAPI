using Service.Models;
using Service.Models.Requests;
using Service.Models.Responses;

namespace Service.Contracts;

public interface IAuthenticationService
{
    Task<ServiceResponse<AuthenticationResponseModel>> Register(AuthenticationRequestModel model);

    Task<ServiceResponse<AuthenticationResponseModel>> Login(AuthenticationRequestModel model);
}
