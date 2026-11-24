namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.Traveloka
{
    public class vmPaymentConfirmationRS //: BaseClass
    {
        public vmPaymentConfirmationRS()
        {
            ErrorType = 0;
            ErrorMessage = "";
        }
        public vmPaymentConfirmationRS(int errorType, string? errorMessage, int statusCode)
        {
            ErrorType = errorType;
            ErrorMessage = errorMessage;
            APIStatusCode = statusCode;
        }
        public bool success { get; set; }
        public string? errorMessage { get; set; }
        public vmConfirmation data { get; set; }

        public int? ErrorType { get; set; }
        public int? APIStatusCode { get; set; }
        public string? ErrorMessage { get; set; }
    }

    public class vmConfirmation
    {
        public string? bookingId { get; set; }
        public string? paymentConfirmationStatus { get; set; }
    }
}
