namespace Api.Models.Responses;

public class ResponseModel
{
    public static ResponseModel Success(object response)
    {
        return new ResponseModel()
        {
            IsError = false,
            ErrorMessage = null,
            Response = response
        };
    }

    public static ResponseModel Failure(string errorMessage)
    {
        return new ResponseModel()
        {
            IsError = true,
            ErrorMessage = errorMessage,
            Response = null
        };
    }

    public bool IsError { get; set; }

    public string ErrorMessage { get; set; }

    public object Response { get; set; }
}


