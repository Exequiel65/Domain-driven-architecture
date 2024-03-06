using Microsoft.Extensions.Logging;
using Packgroup.Ecommerce.Transversal.Common;

namespace Packgroup.Ecommerce.Transversal.Logging
{
    public class LoggerAdapter<T> : IAppLogger<T>
    {
        private readonly ILogger _logger;
        public LoggerAdapter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<T>();
        }
        public void LogInformation(string message, params object[] args)
        {
            _logger.LogInformation(message, args);
        }
        public void LogWarning(string message, params object[] args)
        {
            _logger.LogWarning(message, args);

        }
        public void LogError(string message, params object[] args)
        {
            _logger.LogError(message, args);
        }
    }
}