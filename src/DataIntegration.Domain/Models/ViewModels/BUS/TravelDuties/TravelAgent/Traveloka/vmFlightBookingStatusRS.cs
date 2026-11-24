namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.Traveloka
{
    public class vmFlightBookingStatusRS
    {
        public vmFlightBookingStatusRS()
        {
            ErrorType = 0;
            ErrorMessage = "";
        }
        public vmFlightBookingStatusRS(int errorType, string? errorMessage, int statusCode)
        {
            ErrorType = errorType;
            ErrorMessage = errorMessage;
            APIStatusCode = statusCode;
        }
        public bool success { get; set; }
        public string? errorMessage { get; set; }
        public vmFlightBookingStatusData data { get; set; }

        public int? ErrorType { get; set; }
        public int? APIStatusCode { get; set; }
        public string? ErrorMessage { get; set; }
    }

    public class vmFlightBookingStatusData
    {
        public List<vmBookingStatusResult> bookingStatusResult { get; set; }
    }

    public class vmBookingStatusResult
    {
        public string? bookingId { get; set; }
        public string? status { get; set; }
        public string? issuanceFailedReason { get; set; }
        public string[] pnrCode { get; set; }
        public List<vmEticketInfo> eTicketInfo { get; set; }
    }

    public class vmEticketInfo
    {
        public List<vmFlightPassengerETicketInfo> flightPassengerETicketInfo { get; set; }

    }

    public class vmFlightPassengerETicketInfo
    {
        public string? passengerName { get; set; }
        public string[] eTicketNumber { get; set; }
    }
}
