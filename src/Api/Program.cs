using Api;
using Api.Mapper;
using Api.Models.Responses;
using Microsoft.AspNetCore.Diagnostics;
using Api.Job;
using Hangfire;

var builder = WebApplication.CreateBuilder(args);

await builder.ConfigureServices();

var app = builder.Build();

Console.WriteLine($"Environment is {Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler("/error");

app.Map("/error", (HttpContext context) =>
{
    var error = context.Features.Get<IExceptionHandlerFeature>()?.Error;
    switch (error)
    {
        case BadHttpRequestException:
            return Results.BadRequest(ResponseModel.Failure(error.Message));
        default:
            return Results.Json(data: ResponseModel.Failure(app.Environment.IsDevelopment() ? error.Message : "Something went wrong"), statusCode: 500);
    }
});

ApiModuleMapper.Init();

app.UseHangfireServer();

await app.InitJobsAsync();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseSession();

app.Run();
