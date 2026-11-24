using DataIntegration.Domain.Models.Abstracts;

namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.Traveloka
{
    public class vmFlightBookingStatusRQ 
    {
        public vmFlightBookingStatusRQ()
        {
            ErrorType = 0;
            ErrorMessage = "";
        }
        public vmFlightBookingStatusRQ(int errorType, string? errorMessage, int statusCode)
        {
            ErrorType = errorType;
            ErrorMessage = errorMessage;
            APIStatusCode = statusCode;
        }

        public string[] bookingIds { get; set; }

        public int? ErrorType { get; set; }
        public int? APIStatusCode { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
