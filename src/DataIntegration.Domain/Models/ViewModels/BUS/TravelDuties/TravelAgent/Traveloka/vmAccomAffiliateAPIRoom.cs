namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.Traveloka
{
    public class vmAccomAffiliateAPIRoom
    {
        public string? id { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public List<vmAccomAffiliateImage> images { get; set; }
        public List<vmAccomAffiliateRoomAmenity> amenities { get; set; }
        public string? quotedOccupancy { get; set; }
        public string? maxOccupancy { get; set; }
        public string? smokingPreference { get; set; }
        public vmAccomAffiliateAPIRoomRate rates { get; set; }
        public bool? breakfastIncluded { get; set; }
        public bool? wifiIncluded { get; set; }
        public string? bedType { get; set; }
        public string? bedroomSummary { get; set; }
        public List<vmAccomAffiliateBedRoom> bedrooms { get; set; }
        public vmAccomAffiliateRoomSize roomSize { get; set; }
        public string? roomTypeName { get; set; }
    }
}
