using Packgroup.Ecommerce.Services.WebApi.Modules.Swagger;
using Packgroup.Ecommerce.Services.WebApi.Modules.Authentication;
using Packgroup.Ecommerce.Services.WebApi.Modules.Mapper;
using Packgroup.Ecommerce.Services.WebApi.Modules.Feature;
using Packgroup.Ecommerce.Services.WebApi.Modules.Injection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//AutoMapper
builder.Services.AddMapper();
builder.Services.AddSwagger();
//cors
builder.Services.AddFeature(builder.Configuration);

//Injection
builder.Services.AddInjection();

// configure jwt
builder.Services.AddAuthentication(builder.Configuration);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(FeatureExtensions.myPolicy);
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
