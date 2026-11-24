using DataIntegration.Domain.Models.Abstracts;

namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.Traveloka
{
    public class vmTravelDutiesTravelokaCheckBookingFlightStatus : BaseClass
    {
        public vmTravelDutiesTravelokaCheckBookingFlightStatus()
        {
            ErrorType = 0;
            ErrorMessage = string.Empty;
        }

        public vmTravelDutiesTravelokaCheckBookingFlightStatus(int errorType, string? errorMessage)
        {
            ErrorType = errorType;
            ErrorMessage = errorMessage;
        }

        public bool? IsSuccess { get; set; }
        public string TicketStatus { get; set; }
        public string PaymentStatus { get; set; }
        public string Status { get; set; }
        public string Pnr { get; set; }
        public bool? PaymentConfirmation { get; set; }
    }
}
