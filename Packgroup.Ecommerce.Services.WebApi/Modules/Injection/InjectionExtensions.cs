using Packgroup.Ecommerce.Transversal.Common;
using Packgroup.Ecommerce.Transversal.Logging;

namespace Packgroup.Ecommerce.Services.WebApi.Modules.Injection
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjection(this IServiceCollection services)
        {
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            
            return services;
        }
    }
}
