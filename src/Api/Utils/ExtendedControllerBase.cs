using Api.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Service.Models;

namespace Api.Utils;

public abstract class ExtendedControllerBase : ControllerBase
{
    [NonAction]
    public virtual IActionResult HandleServiceResponse(ServiceResponse serviceResponse)
    {
        if (!serviceResponse.IsSuccessful)
        {
            return StatusCode(500, ResponseModel.Failure(serviceResponse.Error));
        }

        if (serviceResponse.GetType().IsGenericType)
        {
            var propertyInfo = serviceResponse.GetType().GetProperty("Response");
            var response = propertyInfo?.GetValue(serviceResponse, null);
            return Ok(ResponseModel.Success(response));
        }

        return Ok(ResponseModel.Success());
    }
}
