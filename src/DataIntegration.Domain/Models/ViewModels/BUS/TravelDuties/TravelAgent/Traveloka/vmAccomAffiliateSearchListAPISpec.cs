namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.Traveloka
{
    public class vmAccomAffiliateSearchListAPISpec
    {
        public string? checkInDate { get; set; }
        public string? checkOutDate { get; set; }
        public string[] rateTypes { get; set; }
        public vmRoomGroupRequest roomGroup { get; set; }
        public string[] options { get; set; }
        public string? geoId { get; set; }
        public string[] hotelIds { get; set; }
        public string? sortType { get; set; }
        public bool[] stars { get; set; }
        public string? minPrice { get; set; }
        public string? maxPrice { get; set; }
        //public string[] propertyCategories { get; set; }
        public string? limit { get; set; }
        public string? offset { get; set; }
        public vmMetadata metadata { get; set; }
    }

    public class vmRoomGroupRequest
    {
        public string? roomId { get; set; }
        public string? rateKey { get; set; }
        public List<vmRoomRequest> rooms { get; set; }
    }

    public class vmRoomRequest
    {
        public string? numOfAdults { get; set; }
        //public string? rateKey { get; set; }
    }
}
