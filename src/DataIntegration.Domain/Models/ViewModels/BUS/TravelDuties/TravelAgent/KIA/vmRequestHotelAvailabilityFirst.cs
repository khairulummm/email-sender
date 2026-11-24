using DataIntegration.Domain.Models.Abstracts;

namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.KIA
{
    public class vmRequestHotelAvailabilityFirst : BaseClass
    {
        public vmRequestHotelAvailabilityFirst()
        {
            ErrorType = 0;
            ErrorMessage = string.Empty;
        }

        public vmRequestHotelAvailabilityFirst(int errorType, string? errorMessage)
        {
            ErrorType = errorType;
            ErrorMessage = errorMessage;
        }
        public string? GuestPassport { get; set; }
        public string? DestinationKey { get; set; }
        public string? CheckInDate { get; set; }
        public string? CheckOutDate { get; set; }
        public int CountRoom { get; set; }
        public int CountGuest { get; set; }
        public string? HotelName { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? Latitude { get; set; }
        public int? Distance { get; set; }
        public int? MaxPrice { get; set; }
    }
}
