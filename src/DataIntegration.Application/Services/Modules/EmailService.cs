using DataIntegration.Application.Interfaces.Entities.TBIGSYSDB01.TBiGSys;
using DataIntegration.Application.Interfaces.Modules;
using DataIntegration.Application.Model;
using DataIntegration.Application.Models;
using DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys;
using DataIntegration.Infrastructure;
using DataIntegration.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace DataIntegration.Application.Services.Modules
{
    public class EmailService(IUnitOfWorkFactory unitOfWorkFactory, IServiceProvider serviceProvider) : IEmailService
    {
        private readonly RabbitMQSettings _mqSettings;
        private readonly Dictionary<string, string> _appSettings;

        public EmailService(IUnitOfWorkFactory unitOfWorkFactory,
                                   IServiceProvider serviceProvider,
                                   ImstEmailService mstEmailService,
                                   IOptions<RabbitMQSettings> mqOptions,
                                   IOptions<Dictionary<string, string>> appSettings) : this(unitOfWorkFactory, serviceProvider)
        {
            _mqSettings = mqOptions.Value;
            _appSettings = appSettings.Value;
        }

        public async void SendEmail(RabbitMQMessage message)
        {
            try
            {
                var factory = new ConnectionFactory()
                {
                    HostName = _mqSettings.Host,
                    UserName = _mqSettings.Username,
                    Password = CryptoHelper.Decrypt(_mqSettings.Password),
                    Port = _mqSettings.Port,
                    VirtualHost = _mqSettings.Vhost
                };

                string routeKey = _mqSettings.RouteKey + message.Module.ToLower().Replace(" ", "-").Trim();

                using (var connection = await factory.CreateConnectionAsync())
                using (var channel = await connection.CreateChannelAsync())
                {
                    // Declare the exchange if it doesn't already exist (fanout, direct, topic, etc.)
                    await channel.ExchangeDeclareAsync(_mqSettings.ExchangeName, "topic", durable: true, autoDelete: false);

                    // Create a message (convert the string to byte array)
                    string messageBody = JsonConvert.SerializeObject(message);
                    var body = Encoding.UTF8.GetBytes(messageBody);

                    // Send the message to the exchange with the specified routing key
                    await channel.BasicPublishAsync(
                        exchange: _mqSettings.ExchangeName,  // Exchange name
                        routingKey: routeKey,    // Routing key
                                                 //basicProperties: null,   // Basic properties (optional, can be null)
                        body: body               // Message body
                    );
                }

            }
            catch (Exception ex)
            {
                //Helper.LogError(ex.Message.ToString(), "EmailHelper", "SendEmail", strUserID);
            }
        }
    }
}
