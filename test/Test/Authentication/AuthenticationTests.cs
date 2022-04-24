using Data;
using NUnit.Framework;
using Service.Models.Requests;
using System;
using System.Threading.Tasks;

namespace Test.Authentication;

public class ItemTests
{
    [Test]
    public async Task Login_Throws_Exception_If_Input_Is_Null()
    {
        var builder = ItemTestBuilder.Create();
        builder.SetupAuthenticationService();

        Assert.ThrowsAsync<ArgumentNullException>(() => builder.AuthenticationService.Login(null));
    }
    
    [Test]
    public async Task Login_Returns_UserNotFound_If_Profile_Not_Found()
    {
        var builder = ItemTestBuilder.Create();
        builder.SetupAuthenticationService();

        var response = await builder.AuthenticationService.Login(new AuthenticationRequestDTO());

        Assert.IsFalse(response.IsSuccessful);
        Assert.AreEqual(ErrorMessages.UserNotFound, response.Error);
    }

    [Test]
    public async Task Login_Returns_WrongPassword_If_Password_Not_Verified()
    {
        var builder = ItemTestBuilder.Create();
        builder.SetupGetProfileByUserNameAsync("furkan", BCrypt.Net.BCrypt.HashPassword("12345"));
        builder.SetupAuthenticationService();

        var request = new AuthenticationRequestDTO()
        {
            Password = "password1"
        };

        var response = await builder.AuthenticationService.Login(request);

        Assert.IsFalse(response.IsSuccessful);
        Assert.AreEqual(ErrorMessages.WrongPassword, response.Error);
    }

    [Test]
    public async Task Login_Returns_Success_If_Password_Verified()
    {
        var builder = ItemTestBuilder.Create();
        builder.SetupJWTSettings();
        builder.SetupGetProfileByUserNameAsync("furkan", BCrypt.Net.BCrypt.HashPassword("12345"));
        builder.SetupAuthenticationService();

        var request = new AuthenticationRequestDTO()
        {
            Password = "12345"
        };

        var response = await builder.AuthenticationService.Login(request);

        Assert.IsTrue(response.IsSuccessful);
    }

    [Test]
    public async Task Register_Throws_Exception_If_Input_Is_Null()
    {
        var builder = ItemTestBuilder.Create();
        builder.SetupAuthenticationService();

        Assert.ThrowsAsync<ArgumentNullException>(() => builder.AuthenticationService.Register(null));
    }

    [Test]
    public async Task Register_Returns_UserAlreadyExists_If_Profile_Exists()
    {
        var builder = ItemTestBuilder.Create();
        builder.SetupGetProfileByUserNameAsync("furkan", BCrypt.Net.BCrypt.HashPassword("12345"));
        builder.SetupAuthenticationService();

        var response = await builder.AuthenticationService.Register(new AuthenticationRequestDTO());

        Assert.IsFalse(response.IsSuccessful);
        Assert.AreEqual(ErrorMessages.UserAlreadyExists, response.Error);
    }

    [Test]
    public async Task Register_Returns_OperationHasFailed_If_Profile_Creation_Fails()
    {
        var builder = ItemTestBuilder.Create();
        builder.SetupAuthenticationService();

        var request = new AuthenticationRequestDTO()
        {
            Password = "12345"
        };

        var response = await builder.AuthenticationService.Register(request);

        Assert.IsFalse(response.IsSuccessful);
        Assert.AreEqual(ErrorMessages.OperationHasFailed, response.Error);
    }

    [Test]
    public async Task Register_Returns_Success_If_Profile_Is_Being_Created_Successfully()
    {
        var builder = ItemTestBuilder.Create();
        builder.SetupJWTSettings();
        builder.SetupCreateProfileAsync();
        builder.SetupAuthenticationService();

        var request = new AuthenticationRequestDTO()
        {
            Password = "12345"
        };

        var response = await builder.AuthenticationService.Register(request);

        Assert.IsTrue(response.IsSuccessful);
    }
}
