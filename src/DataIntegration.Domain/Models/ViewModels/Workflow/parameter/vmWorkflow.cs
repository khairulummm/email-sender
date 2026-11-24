namespace DataIntegration.Domain.Models.ViewModels.Workflow.parameter
{
    public class vmWorkflow
    {
        public vmWorkflow()
        {
            StatusCode = null;
            JsonError = null;
        }

        public vmWorkflow(int statusCode, string jsonError)
        {
            StatusCode = statusCode;
            JsonError = jsonError;
        }

        public string MessageId { get; set; }
        public string AppId { get; set; }
        public string ContentType { get; set; }
        public string ContentEncoding { get; set; }
        public IDictionary<string, string> Headers { get; set; }
        public byte? DeliveryMode { get; set; }
        public byte? Priority { get; set; }
        public string CorrelationId { get; set; }
        public string ReplyTo { get; set; }
        public string Expiration { get; set; }
        public string Timestamp { get; set; }
        public string Type { get; set; }
        public string UserId { get; set; }
        public vmWorkflowBody Body { get; set; }
        public ulong? DeliveryTag { get; set; }
        public string ConsumerTag { get; set; }
        public bool? Redelivered { get; set; }
        public string Exchange { get; set; }
        public string RoutingKey { get; set; }
        public string WorkerCode { get; set; }
        public string Status { get; set; }

        public int? StatusCode { get; set; }
        public string JsonError { get; set; }
    }
}
