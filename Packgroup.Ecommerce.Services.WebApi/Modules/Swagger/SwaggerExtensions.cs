using Microsoft.OpenApi.Models;

namespace Packgroup.Ecommerce.Services.WebApi.Modules.Swagger
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
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
            return services;
        }
    }
}
