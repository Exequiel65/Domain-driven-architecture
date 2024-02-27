namespace Packgroup.Ecommerce.Services.WebApi.Modules.HealthCheck
{
    public static class HealthChecksExtensions
    {
        public static IServiceCollection AddHealthCheck(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                .AddSqlServer(configuration.GetConnectionString("NorthwindConnection"), tags: new[] { "database" })
                .AddCheck<HealthCheckCustom>("HealthCheckCustom", tags: new[] { "custom" });
                ;
            services.AddHealthChecksUI().AddInMemoryStorage();

            return services;
        }
    }
}
