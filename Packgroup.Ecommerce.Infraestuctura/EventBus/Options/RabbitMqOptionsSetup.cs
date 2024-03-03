﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
namespace Packgroup.Ecommerce.Infraestuctura.EventBus.Options
{
    public class RabbitMqOptionsSetup : IConfigureOptions<RabbitMqOptions>
    {
        private const string ConfigurationSectionName = "RabbitMqOptions";
        private readonly IConfiguration _configuration;

        public RabbitMqOptionsSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(RabbitMqOptions options)
        {
            _configuration.GetSection(ConfigurationSectionName).Bind(options);
        }
    }
}
