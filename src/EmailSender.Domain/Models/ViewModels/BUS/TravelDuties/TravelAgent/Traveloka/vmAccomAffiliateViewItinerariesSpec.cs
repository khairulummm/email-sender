using DataIntegration.Domain.Models.Abstracts;

namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.Traveloka
{
    public class vmAccomAffiliateViewItinerariesSpec : BaseClass
    {
        public vmAccomAffiliateViewItinerariesSpec()
        {
            ErrorType = 0;
            ErrorMessage = "";
            //this.APIStatusCode = 200;
        }
        public vmAccomAffiliateViewItinerariesSpec(int errorType, string? errorMessage, int statusCode)
        {
            ErrorType = errorType;
            ErrorMessage = errorMessage;
        }

        public vmMetadata metadata { get; set; }
        public string? itineraryId { get; set; }
        public vmAccomAffiliateBookingTimeRangeSpec bookingTimeRange { get; set; }
        public string? affiliateConfirmationId { get; set; }
    }

    public class vmAccomAffiliateBookingTimeRangeSpec
    {
        public string? startTime { get; set; }
        public string? endTime { get; set; }
    }
}
