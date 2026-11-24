namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.Traveloka
{
    public class vmAccomAffiliateSearchRoomAPISpec
    {
        public string? propertyId { get; set; }
        public string? checkInDate { get; set; }
        public string? checkOutDate { get; set; }
        public string[] rateTypes { get; set; }
        public vmRoomGroupRequest roomGroup { get; set; }
        public vmMetadata metadata { get; set; }
    }
}
