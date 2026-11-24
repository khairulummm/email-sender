namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.Traveloka
{
    public class vmAccomAffiliateBookingAPIResponse //: BaseClass
    {
        public vmAccomAffiliateBookingAPIResponse()
        {
            ErrorType = 0;
            ErrorMessage = "";
            //this.APIStatusCode = 200;
        }
        public vmAccomAffiliateBookingAPIResponse(int errorType, string? errorMessage, int statusCode)
        {
            ErrorType = errorType;
            ErrorMessage = errorMessage;
            APIStatusCode = statusCode;
        }

        public string? status { get; set; }
        public string? bookingId { get; set; }
        public string? itineraryId { get; set; }
        public string? issuerName { get; set; }
        public string? propertyId { get; set; }
        public vmAccomAffiliatePropertySummary propertySummary { get; set; }
        public string? checkInDate { get; set; }
        public string? checkOutDate { get; set; }
        public List<vmAccomAffiliateBookingRoom> rooms { get; set; }
        public vmRate totalChargeableRate { get; set; }
        public vmAccomAffiliateChargeableRateInfoSpec chargeableRateInfo { get; set; }
        public vmRate convertedTotalChargeableRate { get; set; }
        public List<vmAdditionalRate> additionalRate { get; set; }
        public vmRate surchargeTotal { get; set; }
        public vmRate convertedSurchargeTotal { get; set; }
        public string? bookingTime { get; set; }
        public string? paymentExpirationTime { get; set; }



        public int? ErrorType { get; set; }
        public int? APIStatusCode { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
