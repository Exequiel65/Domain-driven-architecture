using HealthChecks.UI.Client;
using Asp.Versioning.ApiExplorer;
using Packgroup.Ecommerce.Persistence;
using Packgroup.Ecommerce.Aplication.UseCases;
using Packgroup.Ecommerce.Services.WebApi.Modules.Authentication;
using Packgroup.Ecommerce.Services.WebApi.Modules.Feature;
using Packgroup.Ecommerce.Services.WebApi.Modules.HealthCheck;
using Packgroup.Ecommerce.Services.WebApi.Modules.Injection;
using Packgroup.Ecommerce.Services.WebApi.Modules.Swagger;
using Packgroup.Ecommerce.Services.WebApi.Modules.Versioning;
using Packgroup.Ecommerce.Services.WebApi.Modules.Watch;
using Packgroup.Ecommerce.Services.WebApi.Modules.Redis;
using Packgroup.Ecommerce.Services.WebApi.Modules.RateLimiter;
using Packgroup.Ecommerce.Infraestuctura;
using WatchDog;

var builder = WebApplication.CreateBuilder(args);

//cors
builder.Services.AddFeature(builder.Configuration);
//Injection
builder.Services.AddInfrastructureServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddInjection();
// configure jwt
builder.Services.AddAuthentication(builder.Configuration);

builder.Services.AddSwagger();



builder.Services.AddVersioning();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHealthCheck(builder.Configuration);
builder.Services.AddWatchDog(builder.Configuration);
builder.Services.AddRedisCache(builder.Configuration);
builder.Services.AddRateLimiting(builder.Configuration);

var app = builder.Build();
var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
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

// use /api-docs
app.UseReDoc(options =>
{
    foreach (var description in provider.ApiVersionDescriptions)
    {
        options.DocumentTitle = "Packgroup Technology Services API Market";
        options.SpecUrl = $"/swagger/{description.GroupName}/swagger.json";
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


// dotnet tool install -g upgrade-assistant //actualizar proyectos
// tools necesaria herramientas
//dotnet tool install --global dotnet-ef
//  dotnet tool update --global dotnet-ef --version 7.0.4
// Crear Migracion
// dotnet ef migrations add CreateInitialScheme --project Packgroup.Ecommerce.Persistence --startup-project Packgroup.Ecommerce.Services.WebApi --output-dir Migrations --context ApplicationDbContext