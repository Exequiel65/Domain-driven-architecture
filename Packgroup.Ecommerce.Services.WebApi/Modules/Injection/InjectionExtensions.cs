using Packgroup.Ecommerce.Aplication.Interface;
using Packgroup.Ecommerce.Aplication.Main;
using Packgroup.Ecommerce.Domain.Core;
using Packgroup.Ecommerce.Domain.Interface;
using Packgroup.Ecommerce.Infraestructura.Data;
using Packgroup.Ecommerce.Infraestructura.Repository;
using PackGroup.Ecommerce.Infrastructura.Interface;
using Packgroup.Ecommerce.Transversal.Common;
using Packgroup.Ecommerce.Transversal.Logging;

namespace Packgroup.Ecommerce.Services.WebApi.Modules.Injection
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjection(this IServiceCollection services)
        {
            services.AddSingleton<IConectionFactory, ConectionFactory>();
            services.AddScoped<ICustomerApplication, CustomerApplication>();
            services.AddScoped<ICustomerDomain, CustomerDomain>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUsers, UserRepository>();
            services.AddScoped<IUsersDomain, UserDomain>();
            services.AddScoped<IUsersApplication, UserApplication>();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

            return services;
        }
    }
}
