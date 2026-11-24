namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.Traveloka
{
    public class vmAccomAffiliateViewItinerariesResult //: BaseClass
    {
        public vmAccomAffiliateViewItinerariesResult()
        {
            ErrorType = 0;
            ErrorMessage = "";
        }
        public vmAccomAffiliateViewItinerariesResult(int errorType, string? errorMessage, int statusCode)
        {
            ErrorType = errorType;
            ErrorMessage = errorMessage;
            APIStatusCode = statusCode;
        }

        public int totalItineraries { get; set; }
        public List<vmAccomAffiliateItineraryDetail> itineraries { get; set; }

        public int? APIStatusCode { get; set; }
        public int? ErrorType { get; set; }
        public string? ErrorMessage { get; set; }
    }

    public class vmAccomAffiliateItineraryDetail
    {
        public string? itineraryId { get; set; }
        public string? bookingId { get; set; }
        public string? affiliateConfirmationId { get; set; }
        public string? issuerName { get; set; }
        public string? cid { get; set; }
        public string? propertyId { get; set; }
        public string? creationTime { get; set; }
        public string? checkInDate { get; set; }
        public string? checkOutDate { get; set; }
        public vmGuestContact userContact { get; set; }
        public string? currencyCode { get; set; }
        public string? checkInInstruction { get; set; }
        public string? importantNotice { get; set; }
        public List<vmAccomAffiliateViewItineraryRoom> rooms { get; set; }
        public List<vmAccomAffiliateCancellationPolicy> cancellationPolicies { get; set; }
        public string? cancellationPolicyDisplay { get; set; }
        public vmRate totalChargeableRate { get; set; }
        public vmRate convertedTotalChargeableRate { get; set; }
        public List<vmAdditionalRate> additionalRate { get; set; }
        public string? specialRequest { get; set; }
        public string? status { get; set; }
    }

    public class vmAccomAffiliateViewItineraryRoom
    {
        public string? roomId { get; set; }
        public string? name { get; set; }
        public string? roomTypeName { get; set; }
        public string? rateType { get; set; }
        public string? numOfAdults { get; set; }
        public List<vmGuest> guests { get; set; }

        public bool? wifiIncluded { get; set; }
        public bool? breakfastIncluded { get; set; }
        public string? roomStatus { get; set; }
    }
}

