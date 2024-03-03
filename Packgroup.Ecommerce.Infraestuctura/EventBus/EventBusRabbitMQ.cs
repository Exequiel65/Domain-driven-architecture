using Packgroup.Ecommerce.Aplication.Interface.Infraestructure;
using MassTransit;

namespace Packgroup.Ecommerce.Infraestuctura.EventBus
{
    public class EventBusRabbitMQ : IEventBus
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public EventBusRabbitMQ(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async void Publish<T>(T @event)
        {
            await _publishEndpoint.Publish(@event);
        }
    }
}
