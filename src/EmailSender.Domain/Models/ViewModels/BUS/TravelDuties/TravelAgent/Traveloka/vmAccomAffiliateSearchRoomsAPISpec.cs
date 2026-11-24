namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.Traveloka
{
    public class vmAccomAffiliateSearchRoomsAPISpec
    {
        public vmMetadata metadata { get; set; }
        public string? propertyId { get; set; }
        public string? checkInDate { get; set; }
        public string? checkOutDate { get; set; }
        public string[] rateTypes { get; set; }
        public vmRoomGroupRequest roomGroup { get; set; }
        public string[] options { get; set; }
    }
}
