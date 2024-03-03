using Microsoft.Extensions.DependencyInjection;
using Packgroup.Ecommerce.Aplication.Interface.UserCases;
using Packgroup.Ecommerce.Aplication.UseCases.Categories;
using Packgroup.Ecommerce.Aplication.UseCases.Customers;
using Packgroup.Ecommerce.Aplication.UseCases.Discount;
using Packgroup.Ecommerce.Aplication.UseCases.Users;
using Packgroup.Ecommerce.Application.Validator;
using System.Reflection;

namespace Packgroup.Ecommerce.Aplication.UseCases
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<ICustomerApplication, CustomerApplication>();
            services.AddScoped<IUsersApplication, UserApplication>();
            services.AddScoped<ICategoriesApplication, CategoriesApplication>();
            services.AddScoped<IDiscountApplication, DiscountApplication>();

            services.AddTransient<UserDTOValidator>();
            services.AddTransient<DiscountDTOValidator>();

            return services;
        }
    }
}
