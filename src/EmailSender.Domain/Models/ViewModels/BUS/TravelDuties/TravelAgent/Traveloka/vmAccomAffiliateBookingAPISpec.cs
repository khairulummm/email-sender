using DataIntegration.Domain.Models.Abstracts;

namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.Traveloka
{
    public class vmAccomAffiliateBookingAPISpec : BaseClass
    {
        public vmAccomAffiliateBookingAPISpec()
        {
            ErrorType = 0;
            ErrorMessage = "";
            //this.APIStatusCode = 200;
        }
        public vmAccomAffiliateBookingAPISpec(int errorType, string? errorMessage, int statusCode)
        {
            ErrorType = errorType;
            ErrorMessage = errorMessage;
        }

        public vmMetadata metadata { get; set; }
        public string? affiliateConfirmationIds { get; set; }
        public string? propertyId { get; set; }
        public string? checkInDate { get; set; }
        public string? checkOutDate { get; set; }
        public string[] rateTypes { get; set; }
        public List<vmRoomGroupBookingRequest> rooms { get; set; }
        public vmRate expectedTotalChargeableRate { get; set; }
        public vmAccomAffiliateChargeableRateInfoSpec chargeableRateInfo { get; set; }
        public vmGuestContact userContact { get; set; }
        public vmAffiliateContact affiliateContact { get; set; }
        public string? userPaymentMethod { get; set; }
        public string? specialRequest { get; set; }
        public string? loginId { get; set; }
        public string? loginType { get; set; }
    }
}
