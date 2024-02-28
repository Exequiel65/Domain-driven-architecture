using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Packgroup.Ecommerce.Services.WebApi.Modules.Authentication;
using Packgroup.Ecommerce.Services.WebApi.Modules.Feature;
using Packgroup.Ecommerce.Services.WebApi.Modules.HealthCheck;
using Packgroup.Ecommerce.Services.WebApi.Modules.Injection;
using Packgroup.Ecommerce.Services.WebApi.Modules.Mapper;
using Packgroup.Ecommerce.Services.WebApi.Modules.Swagger;
using Packgroup.Ecommerce.Services.WebApi.Modules.Validator;
using Packgroup.Ecommerce.Services.WebApi.Modules.Versioning;

var builder = WebApplication.CreateBuilder(args);

//AutoMapper
builder.Services.AddMapper();
builder.Services.AddSwagger();
//cors
builder.Services.AddFeature(builder.Configuration);

//Injection
builder.Services.AddInjection();

// configure jwt
builder.Services.AddAuthentication(builder.Configuration);

builder.Services.AddVersioning();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddValidator();
builder.Services.AddHealthCheck(builder.Configuration);

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

app.UseCors(FeatureExtensions.myPolicy);
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapHealthChecks("/health", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});
app.MapHealthChecksUI();

app.Run();
