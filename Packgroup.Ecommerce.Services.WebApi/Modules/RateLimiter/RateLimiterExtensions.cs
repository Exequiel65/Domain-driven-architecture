using Microsoft.AspNetCore.RateLimiting;
namespace Packgroup.Ecommerce.Services.WebApi.Modules.RateLimiter
{
    public static class RateLimiterExtensions
    {
        public static IServiceCollection AddRateLimiting(this IServiceCollection services, IConfiguration configuration) 
        {
            var fixedWindowPolicy = "fixedWindow";

            services.AddRateLimiter(confi =>
            {
                confi.AddFixedWindowLimiter(policyName: fixedWindowPolicy, fixedWindw =>
                {
                    fixedWindw.PermitLimit = int.Parse(configuration["RateLimiting:PermitLimit"]);
                    fixedWindw.Window = TimeSpan.FromSeconds(int.Parse(configuration["RateLimiting:Window"]));
                    fixedWindw.QueueProcessingOrder = System.Threading.RateLimiting.QueueProcessingOrder.OldestFirst;
                    fixedWindw.QueueLimit = int.Parse(configuration["RateLimiting:QueueLimit"]);
                });
                confi.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

            });
            return services;
        }

    }
}
