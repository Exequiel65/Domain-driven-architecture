namespace Packgroup.Ecommerce.Services.WebApi.Modules.Redis
{
    public static class RedisExtensions
    {
        public static IServiceCollection AddRedisCache(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddStackExchangeRedisCache(opt =>
            {
                opt.Configuration = configuration.GetConnectionString("RedisConnection");
            });
            return services;
        }
    }
}
