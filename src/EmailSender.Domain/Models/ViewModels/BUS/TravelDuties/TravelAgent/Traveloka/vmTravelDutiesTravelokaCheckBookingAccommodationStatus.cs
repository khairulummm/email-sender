using DataIntegration.Domain.Models.Abstracts;

namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.Traveloka
{
    public class vmTravelDutiesTravelokaCheckBookingAccommodationStatus
    {
        public vmTravelDutiesTravelokaCheckBookingAccommodationStatus()
        {
            ErrorType = 0;
            ErrorMessage = string.Empty;
        }

        public vmTravelDutiesTravelokaCheckBookingAccommodationStatus(int errorType, string? errorMessage, int statusCode)
        {
            ErrorType = errorType;
            ErrorMessage = errorMessage;
            APIStatusCode = statusCode;
        }

        public bool? IsSuccess { get; set; }
        public string BookingID { get; set; }
        public string ItineraryID { get; set; }
        public string Status { get; set; }

        public int? ErrorType { get; set; }
        public int? APIStatusCode { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
