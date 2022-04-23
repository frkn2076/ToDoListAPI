namespace Service.Models;

public class ServiceResponse<T> : ServiceResponse
{
    public T Response { get; set; }

    public static ServiceResponse<T> Success(T response)
    {
        return new()
        {
            IsSuccessful = true,
            Response = response
        };
    }

    public static ServiceResponse<T> Failure(string error)
    {
        return new()
        {
            IsSuccessful = false,
            Error = error
        };
    }
}

public class ServiceResponse
{
    public bool IsSuccessful { get; set; }

    public string Error { get; set; }

    public static ServiceResponse Success()
    {
        return new()
        {
            IsSuccessful = true,
        };
    }

    public static ServiceResponse Failure(string error)
    {
        return new()
        {
            IsSuccessful = false,
            Error = error
        };
    }
}