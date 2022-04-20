namespace Service.Models.Responses;

public class AuthenticationResponseModel
{
    public string AccessToken { get; set; }

    public int AccessTokenExpireDate { get; set; }
}
