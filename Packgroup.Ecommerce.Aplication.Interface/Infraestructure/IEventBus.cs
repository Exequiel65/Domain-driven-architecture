namespace Packgroup.Ecommerce.Aplication.Interface.Infraestructure
{
    public interface IEventBus
    {
        void Publish<T>(T @event);
    }
}
