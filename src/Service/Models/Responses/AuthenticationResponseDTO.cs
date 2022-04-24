namespace Service.Models.Responses;

public class AuthenticationResponseDTO
{
    public string AccessToken { get; set; }

    public int AccessTokenExpireDate { get; set; }
}
