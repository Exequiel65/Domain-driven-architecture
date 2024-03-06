using Asp.Versioning;

namespace Packgroup.Ecommerce.Services.WebApi.Modules.Versioning
{
    public static class VersioningExtensions
    {
        public static IServiceCollection AddVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(o =>
            {
                o.DefaultApiVersion = new ApiVersion(1, 0);
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.ReportApiVersions = true;

                //versiones por queryString
                //o.ApiVersionReader = new QueryStringApiVersionReader("api-version");

                //Versionar por Header
                //o.ApiVersionReader = new HeaderApiVersionReader("x-version");

                //Versionar por URL
                o.ApiVersionReader = new UrlSegmentApiVersionReader();
            }).AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            return services;
        }
    }
}
