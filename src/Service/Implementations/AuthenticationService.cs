﻿using Data;
using Data.Contracts;
using Data.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Service.Contracts;
using Service.Models;
using Service.Models.Requests;
using Service.Models.Responses;
using Service.Utils.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Service.Implementations;

public class AuthenticationService : IAuthenticationService
{
    private readonly IRepository _repository;
    private readonly JWTSettings _jwtSettings;

    public AuthenticationService(IRepository repository, IOptions<JWTSettings> jwtSettings)
    {
        _repository = repository;
        _jwtSettings = jwtSettings.Value;
    }

    public async Task<ServiceResponse<AuthenticationResponseDTO>> RegisterAsync(AuthenticationRequestDTO model)
    {
        ArgumentNullException.ThrowIfNull(model);

        var existingProfile = await _repository.GetProfileByUserNameAsync(model.UserName);

        if (existingProfile != null)
        {
            return ServiceResponse<AuthenticationResponseDTO>.Failure(ErrorMessages.UserAlreadyExists);
        }

        string passwordHash = BCrypt.Net.BCrypt.HashPassword(model.Password);

        var profile = new ProfileEntity()
        {
            UserName = model.UserName,
            Password = passwordHash
        };

        var createdProfile = await _repository.CreateProfileAsync(profile);

        if (createdProfile == null)
        {
            return ServiceResponse<AuthenticationResponseDTO>.Failure(ErrorMessages.OperationHasFailed);
        }

        return await GenerateTokenAsync(createdProfile);
    }

    public async Task<ServiceResponse<AuthenticationResponseDTO>> LoginAsync(AuthenticationRequestDTO model)
    {
        ArgumentNullException.ThrowIfNull(model);

        var profile = await _repository.GetProfileByUserNameAsync(model.UserName);

        if (profile == null)
        {
            return ServiceResponse<AuthenticationResponseDTO>.Failure(ErrorMessages.UserNotFound);
        }

        bool isVerified = BCrypt.Net.BCrypt.Verify(model.Password, profile.Password);

        if (!isVerified)
        {
            return ServiceResponse<AuthenticationResponseDTO>.Failure(ErrorMessages.WrongPassword);
        }

        return await GenerateTokenAsync(profile);
    }

    #region Helper

    private async Task<ServiceResponse<AuthenticationResponseDTO>> GenerateTokenAsync(ProfileEntity user)
    {
        var token = GenerateJwtToken(user);

        var response = new AuthenticationResponseDTO()
        {
            AccessToken = token,
            AccessTokenExpireDate = _jwtSettings.AccessExpireDate,
        };

        return ServiceResponse<AuthenticationResponseDTO>.Success(response);
    }

    private string GenerateJwtToken(ProfileEntity user)
    {
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.SerialNumber, user.Id.ToString())
        };

        if (!string.IsNullOrEmpty(user.UserName))
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.UserName));
        }

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.AccessExpireDate),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }

    #endregion Helper
}
