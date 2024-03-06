using Packgroup.Ecommerce.Services.WebApi.Modules.GlobalException;

namespace Packgroup.Ecommerce.Services.WebApi.Modules.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder AddMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<GlobalExceptionHandler>();
        }
    }
}
