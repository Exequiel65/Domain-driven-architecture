using Packgroup.Ecommerce.Transversal.Mapper;

namespace Packgroup.Ecommerce.Services.WebApi.Modules.Mapper
{
    public static class MapperExtensions
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(x => x.AddProfile(new MappingsProfile()));
            return services;
        }
    }
}
