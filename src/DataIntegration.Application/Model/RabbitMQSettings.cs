namespace DataIntegration.Application.Models
{
    public class RabbitMQSettings
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Vhost { get; set; }
        public string ExchangeName { get; set; }
        public string RouteKey { get; set; }
    }
}
