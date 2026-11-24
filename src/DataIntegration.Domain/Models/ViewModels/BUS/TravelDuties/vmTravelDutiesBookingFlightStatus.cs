using DataIntegration.Domain.Models.Abstracts;

namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties
{
    public class vmTravelDutiesBookingFlightStatus : BaseClass
    {
        public vmTravelDutiesBookingFlightStatus()
        {
            ErrorType = 0;
            ErrorMessage = string.Empty;
        }

        public vmTravelDutiesBookingFlightStatus(int errorType, string? errorMessage)
        {
            ErrorType = errorType;
            ErrorMessage = errorMessage;
        }

        public int TravelDutiesID { get; set; }
        public string ApplicantID { get; set; }
        public int BookingFlightID { get; set; }
        public string AirportOriginCode { get; set; }
        public string AirportOriginName { get; set; }
        public string AirportDestinationCode { get; set; }
        public string AirportDestinationName { get; set; }
        public DateTime FlightDate { get; set; }
        public DateTime LandingDate { get; set; }
        public int TravelAgentID { get; set; }
        public string TravelAgent { get; set; }
        public string BookingStatus { get; set; }
        public string JsonErrMessage { get; set; }
        public bool? IsSuccess { get; set; }
        public int? StatusCode { get; set; }
    }
}
