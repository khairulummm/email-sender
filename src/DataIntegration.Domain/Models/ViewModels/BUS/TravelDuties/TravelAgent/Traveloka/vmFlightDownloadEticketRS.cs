namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.Traveloka
{
    public class vmFlightDownloadEticketRS
    {
        public vmFlightDownloadEticketRS()
        {
            ErrorType = 0;
            ErrorMessage = "";
        }
        public vmFlightDownloadEticketRS(int errorType, string? errorMessage, int statusCode)
        {
            ErrorType = errorType;
            ErrorMessage = errorMessage;
            APIStatusCode = statusCode;
        }
        public vmEticket data { get; set; }
        public bool success { get; set; }
        public object errorMessage { get; set; }

        public int? ErrorType { get; set; }
        public int? APIStatusCode { get; set; }
        public string? ErrorMessage { get; set; }
    }

    public class vmEticket
    {
        public List<vmEticketData> etickets { get; set; }
    }

    public class vmEticketData
    {
        public string? ticketId { get; set; }
        public string? url { get; set; }
    }


}
