namespace Service.Utils.Models;

public class JWTSettings
{
    public string SecretKey { get; set; }

    public int AccessExpireDate { get; set; }
}
