using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Packgroup.Ecommerce.Services.WebApi.Modules.Swagger
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen(options =>
            {
                //options.SwaggerDoc("v1", new OpenApiInfo
                //{
                //    Title = "Packgroup Technology Services API Market",
                //    Version = "v1",
                //    Description = "A simple example ASP.NET Core Web Api",
                //    TermsOfService = null,
                //    Contact = new OpenApiContact
                //    {
                //        Name = "Marcos Britos",
                //        Email = "email@example.com",
                //        Url = new Uri("https://pacagroup.com")
                //    },
                //    License = new OpenApiLicense
                //    {
                //        Name = "Use under LICX",
                //        Url = new Uri("htpps://pacagroup.com")
                //    }
                //});

                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "Enter JWT Bearer token **_only_**",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                options.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { securityScheme, new List<string>(){ } }
                });
                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //options.IncludeXmlComments(xmlPath);

            });
            return services;
        }
    }
}
