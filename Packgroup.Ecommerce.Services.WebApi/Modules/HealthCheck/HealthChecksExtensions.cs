namespace Packgroup.Ecommerce.Services.WebApi.Modules.HealthCheck
{
    public static class HealthChecksExtensions
    {
        public static IServiceCollection AddHealthCheck(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                .AddSqlServer(configuration.GetConnectionString("NorthwindConnection"), tags: new[] { "database" })
                .AddRedis(configuration.GetConnectionString("RedisConnection"), tags: new[] { "cache-redis" })
                .AddCheck<HealthCheckCustom>("HealthCheckCustom", tags: new[] { "custom" });
            //.AddRabbitMQ(new Uri(configuration["RabbitMqOptions:HostName"]), name: "rabbitmq-check", tags: new[] { "rabbitmq" });
            //services.AddHealthChecksUI().AddInMemoryStorage();

            services.AddHealthChecksUI().AddSqlServerStorage(configuration.GetConnectionString("NorthwindConnection"));

            return services;
        }
    }
}
