using Data.Contracts;
using Data.Entities;
using Microsoft.Extensions.Options;
using Moq;
using Service.Contracts;
using Service.Implementations;
using Service.Utils.Models;
using System.Data;

namespace Test.Authentication;

public class AuthenticationBuilder
{
    public static AuthenticationBuilder Create() => new();

    public IAuthenticationService AuthenticationService;
    private Mock<IRepository> _repository { get; set; } = new Mock<IRepository>();
    private Mock<IOptions<JWTSettings>> _jwtSettings { get; set; } = new Mock<IOptions<JWTSettings>>();

    public void SetupAuthenticationService()
    {
        AuthenticationService = new AuthenticationService(_repository.Object, _jwtSettings.Object);
    }

    public void SetupGetProfileByUserNameAsync(string username, string password)
    {
        var profile = new ProfileEntity()
        {
            UserName = username,
            Password = password
        };

        _repository.Setup(x => x.GetProfileByUserNameAsync(It.IsAny<string>(), It.IsAny<IDbTransaction>())).ReturnsAsync(profile);
    }

    public void SetupCreateProfileAsync()
    {
        _repository.Setup(x => x.CreateProfileAsync(It.IsAny<ProfileEntity>(), It.IsAny<IDbTransaction>())).ReturnsAsync(new ProfileEntity());
    }

    public void SetupJWTSettings()
    {
        var jwtSettings = new JWTSettings()
        {
            SecretKey = "SECRET KEY SECRET KEY SECRET KEY SECRET KEY SECRET KEY",
            AccessExpireDate = 100
        };

        _jwtSettings.Setup(x => x.Value).Returns(jwtSettings);
    }
}
