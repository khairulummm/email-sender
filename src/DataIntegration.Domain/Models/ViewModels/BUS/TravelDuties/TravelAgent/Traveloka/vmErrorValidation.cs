namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.Traveloka
{
    public class vmErrorValidation
    {
        public string? category { get; set; }
        public string? handling { get; set; }
        public string? errorCode { get; set; }
        public string? message { get; set; }
        public string? verboseMessage { get; set; }
        public string? serverTimestamp { get; set; }
        public object data { get; set; }
    }
}
