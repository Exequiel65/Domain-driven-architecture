namespace Packgroup.Ecommerce.Aplication.Interface.Infraestructure
{
    public interface INotification
    {
        Task<bool> SendMailAsync(string subject, string body, CancellationToken cancellationToken = new());
    }
}
