using DataIntegration.Domain.Models.Abstracts;

namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.KIA
{
    public class vmTravelDutiesKiaCheckBookingFlightStatus : BaseClass
    {
        public vmTravelDutiesKiaCheckBookingFlightStatus()
        {
            ErrorType = 0;
            ErrorMessage = string.Empty;
        }

        public vmTravelDutiesKiaCheckBookingFlightStatus(int errorType, string? errorMessage)
        {
            ErrorType = errorType;
            ErrorMessage = errorMessage;
        }
        public bool? IsSuccess { get; set; }
        public string BookingID { get; set; }
        public string BookingCode { get; set; }
        public string Status { get; set; }
        public string TicketNumber { get; set; }
        public decimal Total { get; set; }
    }
}
