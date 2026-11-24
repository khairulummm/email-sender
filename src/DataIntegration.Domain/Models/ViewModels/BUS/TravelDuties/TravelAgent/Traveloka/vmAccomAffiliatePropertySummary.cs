namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.Traveloka
{
    public class vmAccomAffiliatePropertySummary
    {
        public string? name { get; set; }
        public string? formerName { get; set; }
        public vmAccomAffiliateAddress address { get; set; }
        public string? phoneNumber { get; set; }
        public vmAccomAffiliateAddress localAddress { get; set; }
        public string? starRating { get; set; }
        public string? reviewScore { get; set; }
        public string? accommodationType { get; set; }
        public vmAccomAffiliateGeoLocation geoLocation { get; set; }
        public string? countryISO { get; set; }
    }
}
