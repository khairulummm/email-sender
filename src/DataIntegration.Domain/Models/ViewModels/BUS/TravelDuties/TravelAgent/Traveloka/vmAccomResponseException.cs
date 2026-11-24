namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.Traveloka
{

    public class vmAccomResponseException
    {
        public string? category { get; set; }
        public string? handling { get; set; }
        public string? errorCode { get; set; }
        public string? message { get; set; }
        public string? verboseMessage { get; set; }
        public string? serverTimestamp { get; set; }

        public ExceptionData data { get; set; }
        public int? APIStatusCode { get; set; }
    }

    public class ExceptionData
    {
        public string? requestedTotalFare { get; set; }
        public string? requestedCurrency { get; set; }
        public string? currentRate { get; set; }
        public string? currentCurrency { get; set; }
    }
}
