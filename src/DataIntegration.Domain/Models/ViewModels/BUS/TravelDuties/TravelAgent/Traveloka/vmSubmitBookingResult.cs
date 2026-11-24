using DataIntegration.Domain.Models.Abstracts;

namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.Traveloka
{
    public class vmSubmitBookingResult : BaseClass
    {
        public vmSubmitBookingResult()
        {
            ErrorType = 0;
            ErrorMessage = "";
            //this.APIStatusCode = 200;
        }
        public vmSubmitBookingResult(int errorType, string? errorMessage, int statusCode)
        {
            ErrorType = errorType;
            ErrorMessage = errorMessage;
        }

        public vmAccomAffiliateBookingAPIResponse BookingResponse { get; set; }
        public string ConfirmationID { get; set; }
        public int? Revision { get; set; }
    }
}
