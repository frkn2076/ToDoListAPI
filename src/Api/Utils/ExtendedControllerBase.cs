using Api.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Service.Models;

namespace Api.Utils;

public abstract class ExtendedControllerBase : ControllerBase
{
    public virtual IActionResult HandleServiceResponse<T>(ServiceResponse<T> serviceResponse)
    {
        if (!serviceResponse.IsSuccessful)
        {
            return StatusCode(500, ResponseModel.Failure(serviceResponse.Error));
        }

        return Ok(ResponseModel.Success(serviceResponse.Response));
    }
}
