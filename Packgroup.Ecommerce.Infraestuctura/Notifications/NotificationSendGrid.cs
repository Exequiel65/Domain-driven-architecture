using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Packgroup.Ecommerce.Aplication.Interface.Infraestructure;
using Packgroup.Ecommerce.Infraestuctura.Notifications.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Text.Json;

namespace Packgroup.Ecommerce.Infraestuctura.Notifications
{
    public class NotificationSendGrid : INotification
    {
        private readonly ILogger<NotificationSendGrid> _logger;
        private readonly SendgridOptions _sendgridOptions;
        private readonly ISendGridClient _sendGridClient;

        public NotificationSendGrid(ILogger<NotificationSendGrid> logger, IOptions<SendgridOptions> sendgridOptions, ISendGridClient sendGridClient)
        {
            _logger = logger;
            _sendgridOptions = sendgridOptions.Value;
            _sendGridClient = sendGridClient;
        }

        public async Task<bool> SendMailAsync(string subject, string body, CancellationToken cancellationToken = default)
        {
            SendGridMessage message = BuildMessage(subject, body);
            Response? response = await _sendGridClient.SendEmailAsync(message).ConfigureAwait(false);
            _logger.LogInformation(JsonSerializer.Serialize(response));
            if (response.IsSuccessStatusCode)
            {
                _logger.LogInformation("Email enviado");
                return true;
            }

            _logger.LogError("Email fallido");
            
            return false;
        }


        public SendGridMessage BuildMessage(string subject, string body)
        {
            SendGridMessage message = new SendGridMessage() 
            {
                From = new EmailAddress(_sendgridOptions.FromEmail),
                Subject = subject,
            };
            message.AddContent(MimeType.Text, body);
            message.AddTo(new EmailAddress(_sendgridOptions.ToAddress, _sendgridOptions.ToUser));

            if (_sendgridOptions.SandboxMode)
            {
                message.MailSettings = new MailSettings { SandboxMode = new SandboxMode { Enable = true } };
            }

            return message;
        }
    }
}
