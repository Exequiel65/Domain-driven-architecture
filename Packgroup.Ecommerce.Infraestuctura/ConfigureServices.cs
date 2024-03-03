using Microsoft.Extensions.DependencyInjection;
using MassTransit;
using Packgroup.Ecommerce.Infraestuctura.EventBus.Options;
using Packgroup.Ecommerce.Aplication.Interface.Infraestructure;
using Packgroup.Ecommerce.Infraestuctura.EventBus;
using Microsoft.Extensions.Options;

namespace Packgroup.Ecommerce.Infraestuctura
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.ConfigureOptions<RabbitMqOptionsSetup>();
            services.AddScoped<IEventBus, EventBusRabbitMQ>();
            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, cfg) =>
                {
                    RabbitMqOptions? opt = services.BuildServiceProvider()
                    .GetRequiredService<IOptions<RabbitMqOptions>>()
                    .Value;

                    cfg.Host(opt.HostName, opt.VirtualHost, h =>
                    {
                        h.Username(opt.UserName);
                        h.Password(opt.Password);
                    });

                    cfg.ConfigureEndpoints(context);
                });
            });

            return services;
        }
    }
}