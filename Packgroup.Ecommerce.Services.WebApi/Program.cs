using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Packgroup.Ecommerce.Persistence;
using Packgroup.Ecommerce.Aplication.UseCases;
using Packgroup.Ecommerce.Services.WebApi.Modules.Authentication;
using Packgroup.Ecommerce.Services.WebApi.Modules.Feature;
using Packgroup.Ecommerce.Services.WebApi.Modules.HealthCheck;
using Packgroup.Ecommerce.Services.WebApi.Modules.Injection;
using Packgroup.Ecommerce.Services.WebApi.Modules.Mapper;
using Packgroup.Ecommerce.Services.WebApi.Modules.Swagger;
using Packgroup.Ecommerce.Services.WebApi.Modules.Validator;
using Packgroup.Ecommerce.Services.WebApi.Modules.Versioning;
using Packgroup.Ecommerce.Services.WebApi.Modules.Watch;
using Packgroup.Ecommerce.Services.WebApi.Modules.Redis;
using Packgroup.Ecommerce.Services.WebApi.Modules.RateLimiter;
using WatchDog;

var builder = WebApplication.CreateBuilder(args);
//AutoMapper
builder.Services.AddMapper();
//cors
builder.Services.AddFeature(builder.Configuration);
//Injection
builder.Services.AddPersistenceServices();
builder.Services.AddApplicationServices();
builder.Services.AddInjection();
// configure jwt
builder.Services.AddAuthentication(builder.Configuration);

builder.Services.AddSwagger();



builder.Services.AddVersioning();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddValidator();
builder.Services.AddHealthCheck(builder.Configuration);
builder.Services.AddWatchDog(builder.Configuration);
builder.Services.AddRedisCache(builder.Configuration);
builder.Services.AddRateLimiting(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
        foreach (var description in provider.ApiVersionDescriptions)
        {
            c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
        }
    });
//}

app.UseHttpsRedirection();
app.UseWatchDogExceptionLogger();
app.UseCors(FeatureExtensions.myPolicy);
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseRateLimiter();
app.UseEndpoints(_ => { });
app.MapControllers();
app.MapHealthChecks("/health", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});
app.MapHealthChecksUI();

app.UseWatchDog(conf =>
{
    conf.WatchPageUsername = builder.Configuration["WatchDog:WatchPageUserName"];
    conf.WatchPagePassword = builder.Configuration["WatchDog:WatchPagePassword"];
});

app.Run();


public partial class Program { };
