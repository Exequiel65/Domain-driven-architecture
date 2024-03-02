using Microsoft.Extensions.DependencyInjection;
using Packgroup.Ecommerce.Aplication.Interface.UserCases;
using Packgroup.Ecommerce.Aplication.UseCases.Categories;
using Packgroup.Ecommerce.Aplication.UseCases.Customers;
using Packgroup.Ecommerce.Aplication.UseCases.Users;

namespace Packgroup.Ecommerce.Aplication.UseCases
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ICustomerApplication, CustomerApplication>();
            services.AddScoped<IUsersApplication, UserApplication>();
            services.AddScoped<ICategoriesApplication, CategoriesApplication>();

            return services;
        }
    }
}
