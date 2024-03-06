using Packgroup.Ecommerce.Transversal.Common;
using System.Net;
using System.Text.Json;

namespace Packgroup.Ecommerce.Services.WebApi.Modules.GlobalException
{
    public class GlobalExceptionHandler : IMiddleware
    {
        private ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                _logger.LogError($"Exception Details: {message}");

                var response = new Response<object>()
                {
                    Message = message,
                };
                await JsonSerializer.SerializeAsync(context.Response.Body, response);
            }
        }
    }
}
