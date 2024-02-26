namespace Packgroup.Ecommerce.Services.WebApi.Modules.Feature
{
    public static class FeatureExtensions
    {
        public static string myPolicy = "policyApiCommerce";
        public static IServiceCollection AddFeature(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options => options.AddPolicy(myPolicy, b => b.WithOrigins(configuration["Config:OriginCors"])
                                                                        .AllowAnyHeader()
                                                                        .AllowAnyMethod()));

            return services;
        }
    }
}
