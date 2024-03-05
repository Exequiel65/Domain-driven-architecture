using MassTransit;
using Packgroup.Ecommerce.Domain.Events;
using System.Text.Json;

namespace Packgroup.Ecommerce.ConsoleApp.Consumer
{
    public class DiscountCreatedConsumer : IConsumer<DiscountCreatedEvent>
    {
        public async Task Consume(ConsumeContext<DiscountCreatedEvent> context)
        {
            var jsonMessage = JsonSerializer.Serialize(context.Message);
            await Console.Out.WriteLineAsync($"Mensagge from producer : {jsonMessage}");
        }
    }
}
