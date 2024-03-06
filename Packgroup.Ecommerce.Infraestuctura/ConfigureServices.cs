using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Packgroup.Ecommerce.Aplication.Interface.Infraestructure;
using Packgroup.Ecommerce.Infraestuctura.EventBus;
using Packgroup.Ecommerce.Infraestuctura.EventBus.Options;
using Packgroup.Ecommerce.Infraestuctura.Notifications;
using Packgroup.Ecommerce.Infraestuctura.Notifications.Options;
using SendGrid.Extensions.DependencyInjection;

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

            //sendgrid
            services.AddScoped<INotification, NotificationSendGrid>();
            services.ConfigureOptions<SendgridOptionsSetup>();
            SendgridOptions? sendgridOptions = services.BuildServiceProvider()
                .GetRequiredService<IOptions<SendgridOptions>>()
                .Value;
            services.AddSendGrid(options =>
            {
                options.ApiKey = sendgridOptions.ApiKey;
            });

            return services;
        }
    }
}