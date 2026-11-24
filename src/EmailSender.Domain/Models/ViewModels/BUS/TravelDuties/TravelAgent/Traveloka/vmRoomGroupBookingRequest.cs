namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.Traveloka
{
    public class vmRoomGroupBookingRequest
    {
        public string? roomId { get; set; }
        public string? rateKey { get; set; }
        public string? numOfAdult { get; set; }
        public List<vmGuest> guests { get; set; }
    }
}