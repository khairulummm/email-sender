using DataIntegration.Domain.Models.Abstracts;

namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.Traveloka
{
    public class vmFlightBookingRS
    {
        public vmFlightBookingRS()
        {
            ErrorType = 0;
            ErrorMessage = "";
        }
        public vmFlightBookingRS(int errorType, string? errorMessage, int statusCode)
        {
            ErrorType = errorType;
            ErrorMessage = errorMessage;
            APIStatusCode = statusCode;
        }

        public bool success { get; set; }
        public string? errorMessage { get; set; }
        public string? errorType { get; set; }
        public vmFlightBookingResult data { get; set; }

        public int? APIStatusCode { get; set; }
        public int? ErrorType { get; set; }
        public string? ErrorMessage { get; set; }
    }

    public class vmFlightBookingResult
    {
        public string? bookingSubmissionStatus { get; set; }
        public string? bookingId { get; set; }
        public string? paymentExpirationTime { get; set; }
        public vmBookingDetail flightBookingDetail { get; set; }
    }

    public class vmBookingDetail
    {
        public vmContactDetail contactDetail { get; set; }
        public vmPassengerContact passengers { get; set; }
        public string? locale { get; set; }
        public string? status { get; set; }
        public string? issuanceFailedReason { get; set; }
        public vmFare fareDetail { get; set; }
        public List<vmFlightJourney> journeys { get; set; }
        public vmAmount grandTotalFareWithCurrency { get; set; }
        public string? bookingTime { get; set; }
    }

}
