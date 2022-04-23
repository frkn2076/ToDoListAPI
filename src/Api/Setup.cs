using Api.Extension;
using Data.Contracts;
using Data.Implementations;
using Data.Utils.Models;
using Service.Contracts;
using Service.Implementations;
using Service.Utils.Models;
using Data;
using Data.Utils;
using Dapper;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Api.Filters;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

namespace Api;

public static class Setup
{
    public static async void ConfigureServices(this WebApplicationBuilder builder)
    {
        var services = builder.Services;

        builder.Services.AddControllers(options =>
        {
            options.Filters.Add(typeof(ValidateModelStateAttribute));
        })
        .AddFluentValidation(s =>
        {
            s.RegisterValidatorsFromAssemblyContaining<Program>();
        });

        builder.Services.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });

        services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(opt =>
        {
            opt.SwaggerDoc("v1", new OpenApiInfo()
            {
                Version = "v1",
                Title = "ToDoList API",
                Description = "An API for managing tasks of the user"
            });
        });

        services.AddHttpContextAccessor();

        services.AddSession(option =>
        {
            option.IdleTimeout = TimeSpan.FromMinutes(1);
        });

        services.AddDistributedMemoryCache();

        services.Configure<ConnectionStrings>(builder.Configuration.GetSection(nameof(ConnectionStrings)));
        services.Configure<JWTSettings>(builder.Configuration.GetSection(nameof(JWTSettings)));

        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        services.AddTransient<IConnectionService, ConnectionService>();
        services.AddTransient<IRepository, Repository>();

        services.AddTransient<IAuthenticationService, AuthenticationService>();
        services.AddTransient<IItemService, ItemService>();

        services.AddScoped<CurrentUser>();

        var jwtSettings = builder.Configuration.GetOptions<JWTSettings>();
        services.RegisterJWTAuthorization(jwtSettings);

        var serviceProvider = services.BuildServiceProvider();
    }

    #region Helper

    private static void RegisterJWTAuthorization(this IServiceCollection services, JWTSettings settings)
    {
        var key = Encoding.ASCII.GetBytes(settings.SecretKey);
        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });
    }

    #endregion Helper
}
