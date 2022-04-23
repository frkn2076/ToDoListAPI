using System.Security.Claims;

namespace Api;

public class CurrentUser
{
    private readonly ClaimsIdentity _claimsIdentity;

    public int Id => GetId();
    public string UserName => GetUserName();
    public int TimeZone => GetTimeZone();

    public CurrentUser(IHttpContextAccessor httpContextAccessor)
    {
        _claimsIdentity = httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
    }

    private int GetId()
    {
        var idClaim = _claimsIdentity.FindFirst(ClaimTypes.SerialNumber)?.Value;
        int.TryParse(idClaim, out int id);
        return id;
    }

    private string? GetUserName()
    {
        return _claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    }

    private int GetTimeZone()
    {
        var idClaim = _claimsIdentity.FindFirst(ClaimTypes.System)?.Value;
        int.TryParse(idClaim, out int id);
        return id;
    }
}
