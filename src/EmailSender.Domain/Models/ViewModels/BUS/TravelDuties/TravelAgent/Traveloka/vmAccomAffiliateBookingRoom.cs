namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.Traveloka
{
    public class vmAccomAffiliateBookingRoom
    {
        public string? id { get; set; }
        public string? name { get; set; }
        public string? numOfAdults { get; set; }
        public List<vmGuest> guests { get; set; }
        public bool? wifiIncluded { get; set; }
        public bool? breakfastIncluded { get; set; }
        public string? bedType { get; set; }
        public string? roomTypeName { get; set; }
    }
}