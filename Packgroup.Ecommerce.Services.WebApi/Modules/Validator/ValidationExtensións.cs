using Packgroup.Ecommerce.Application.Validator;

namespace Packgroup.Ecommerce.Services.WebApi.Modules.Validator
{
    public static class ValidationExtensións
    {
        public static IServiceCollection AddValidator(this IServiceCollection services)
        {
            //add Transient se crea una instancia en cada peticion
            services.AddTransient<UserDTOValidator>();
            return services;
        }
    }
}
