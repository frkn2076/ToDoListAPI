using Data;
using NUnit.Framework;
using Service.Models.Requests;
using System;
using System.Threading.Tasks;

namespace Test.Authentication;

public class AuthenticationTests
{
    [Test]
    public async Task LoginAsync_Throws_Exception_If_Input_Is_Null()
    {
        var builder = AuthenticationBuilder.Create();
        builder.SetupAuthenticationService();

        Assert.ThrowsAsync<ArgumentNullException>(() => builder.AuthenticationService.LoginAsync(null));
    }
    
    [Test]
    public async Task LoginAsync_Returns_UserNotFound_If_Profile_Not_Found()
    {
        var builder = AuthenticationBuilder.Create();
        builder.SetupAuthenticationService();

        var response = await builder.AuthenticationService.LoginAsync(new AuthenticationRequestDTO());

        Assert.IsFalse(response.IsSuccessful);
        Assert.AreEqual(ErrorMessages.UserNotFound, response.Error);
    }

    [Test]
    public async Task LoginAsync_Returns_WrongPassword_If_Password_Not_Verified()
    {
        var builder = AuthenticationBuilder.Create();
        builder.SetupGetProfileByUserNameAsync("furkan", BCrypt.Net.BCrypt.HashPassword("12345"));
        builder.SetupAuthenticationService();

        var request = new AuthenticationRequestDTO()
        {
            Password = "password1"
        };

        var response = await builder.AuthenticationService.LoginAsync(request);

        Assert.IsFalse(response.IsSuccessful);
        Assert.AreEqual(ErrorMessages.WrongPassword, response.Error);
    }

    [Test]
    public async Task LoginAsync_Returns_Success_If_Password_Verified()
    {
        var builder = AuthenticationBuilder.Create();
        builder.SetupJWTSettings();
        builder.SetupGetProfileByUserNameAsync("furkan", BCrypt.Net.BCrypt.HashPassword("12345"));
        builder.SetupAuthenticationService();

        var request = new AuthenticationRequestDTO()
        {
            Password = "12345"
        };

        var response = await builder.AuthenticationService.LoginAsync(request);

        Assert.IsTrue(response.IsSuccessful);
    }

    [Test]
    public async Task RegisterAsync_Throws_Exception_If_Input_Is_Null()
    {
        var builder = AuthenticationBuilder.Create();
        builder.SetupAuthenticationService();

        Assert.ThrowsAsync<ArgumentNullException>(() => builder.AuthenticationService.RegisterAsync(null));
    }

    [Test]
    public async Task RegisterAsync_Returns_UserAlreadyExists_If_Profile_Exists()
    {
        var builder = AuthenticationBuilder.Create();
        builder.SetupGetProfileByUserNameAsync("furkan", BCrypt.Net.BCrypt.HashPassword("12345"));
        builder.SetupAuthenticationService();

        var response = await builder.AuthenticationService.RegisterAsync(new AuthenticationRequestDTO());

        Assert.IsFalse(response.IsSuccessful);
        Assert.AreEqual(ErrorMessages.UserAlreadyExists, response.Error);
    }

    [Test]
    public async Task RegisterAsync_Returns_OperationHasFailed_If_Profile_Creation_Fails()
    {
        var builder = AuthenticationBuilder.Create();
        builder.SetupAuthenticationService();

        var request = new AuthenticationRequestDTO()
        {
            Password = "12345"
        };

        var response = await builder.AuthenticationService.RegisterAsync(request);

        Assert.IsFalse(response.IsSuccessful);
        Assert.AreEqual(ErrorMessages.OperationHasFailed, response.Error);
    }

    [Test]
    public async Task RegisterAsync_Returns_Success_If_Profile_Is_Being_Created_Successfully()
    {
        var builder = AuthenticationBuilder.Create();
        builder.SetupJWTSettings();
        builder.SetupCreateProfileAsync();
        builder.SetupAuthenticationService();

        var request = new AuthenticationRequestDTO()
        {
            Password = "12345"
        };

        var response = await builder.AuthenticationService.RegisterAsync(request);

        Assert.IsTrue(response.IsSuccessful);
    }
}
