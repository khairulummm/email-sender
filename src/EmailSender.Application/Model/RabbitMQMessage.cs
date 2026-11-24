namespace DataIntegration.Application.Model
{
    public class RabbitMQMessage
    {
        public string Subject { get; set; }
        public string HTMLBody { get; set; }
        public int ApplicationID { get; set; }
        public string Module { get; set; }
        public string TemplateCode { get; set; }
        public List<string> To { get; set; }
        public List<string> CC { get; set; }
        public List<string> BCC { get; set; }
        public List<string> Attachment { get; set; }
    }
}
