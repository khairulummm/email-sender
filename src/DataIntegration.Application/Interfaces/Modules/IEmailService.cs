using DataIntegration.Application.Model;

namespace DataIntegration.Application.Interfaces.Modules
{
    public interface IEmailService
    {
        void SendEmail(RabbitMQMessage parameter);
    }
}
