using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Packgroup.Ecommerce.Services.WebApi.Modules.Swagger
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
            }
        }

        static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new OpenApiInfo
            {
                Title = "Packgroup Technology Services API Market",
                Version = description.ApiVersion.ToString(),
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
            };

            return info;
        }
    }
}
