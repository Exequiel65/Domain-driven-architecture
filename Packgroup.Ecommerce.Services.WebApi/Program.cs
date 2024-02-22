using Microsoft.OpenApi.Models;
using Packgroup.Ecommerce.Aplication.Interface;
using Packgroup.Ecommerce.Aplication.Main;
using Packgroup.Ecommerce.Domain.Core;
using Packgroup.Ecommerce.Domain.Interface;
using Packgroup.Ecommerce.Infraestructura.Data;
using Packgroup.Ecommerce.Infraestructura.Repository;
using Packgroup.Ecommerce.Transversal.Common;
using Packgroup.Ecommerce.Transversal.Mapper;
using PackGroup.Ecommerce.Infrastructura.Interface;

var builder = WebApplication.CreateBuilder(args);
var myPolicy = "policyApiCommerce";
// Add services to the container.
//AutoMapper
builder.Services.AddAutoMapper(x => x.AddProfile(new MappingsProfile()));

//cors
builder.Services.AddCors(options => options.AddPolicy(myPolicy, b => b.WithOrigins(builder.Configuration["Config:OriginCors"])
                                                                        .AllowAnyHeader()
                                                                        .AllowAnyMethod()));
                                                                        

builder.Services.AddSingleton<IConectionFactory, ConectionFactory>();
builder.Services.AddScoped<ICustomerApplication, CustomerApplication>();
builder.Services.AddScoped<ICustomerDomain, CustomerDomain>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Packgroup Technology Services API Market",
        Version = "v1",
        Description = "A simple example ASP.NET Core Web Api",
        TermsOfService = null,
        Contact = new OpenApiContact
        {
            Name = "Marcos Britos",
            Email = "email@example.com",
            Url = new Uri("https://pacagroup.com")
        },
        License = new OpenApiLicense
        {
            Name = "Use under LICX",
            Url = new Uri("htpps://pacagroup.com")
        }
    });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Auhtorization",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"

    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type= ReferenceType.SecurityScheme,
                    Id="Bearer",
                }
            },
            new string[] {}
        }
    });
    //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}";
    //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    //options.IncludeXmlComments(xmlPath);

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(myPolicy);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
