namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.Traveloka
{
    public class vmAccomAffiliateCancellationPolicy
    {
        public string? currencyCode { get; set; }
        public string? timeZoneDisplay { get; set; }
        public string? cancelDateTime { get; set; }
        public string? fees { get; set; }
        public bool isAfter { get; set; }
    }
}
