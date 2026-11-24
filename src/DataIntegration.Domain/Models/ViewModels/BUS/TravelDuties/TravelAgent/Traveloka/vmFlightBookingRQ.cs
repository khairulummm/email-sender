using DataIntegration.Domain.Models.Abstracts;

namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.Traveloka
{
    public class vmFlightBookingRQ : BaseClass
    {
        public vmFlightBookingRQ()
        {
            ErrorType = 0;
            ErrorMessage = "";
        }
        public vmFlightBookingRQ(int errorType, string? errorMessage)
        {
            ErrorType = errorType;
            ErrorMessage = errorMessage;
        }

        public vmContactDetail contactDetail { get; set; }
        public vmPassengerContact passengers { get; set; }
        public string[] flightIds { get; set; }
        public string? journeyType { get; set; }
        public string? locale { get; set; }
        public string? username { get; set; }
        public string? loginID { get; set; }
        public string? loginType { get; set; }
        public string? customerLoginID { get; set; }
        public string? customerLoginType { get; set; }
    }

    public class vmContactDetail
    {
        public string? email { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? phoneNumber { get; set; }
        public string? phoneNumberCountryCode { get; set; }
        public string? customerEmail { get; set; }
        public string? customerPhoneNumber { get; set; }
        public string? customerPhoneNumberCountryCode { get; set; }
    }

    public class vmPassengerContact
    {
        public List<vmPassengerContactDetail> adults { get; set; }
        public List<vmPassengerContactDetail> children { get; set; }
        public List<vmPassengerContactDetail> infants { get; set; }
    }

    public class vmPassengerContactDetail
    {
        public string? title { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? gender { get; set; }
        public string? dateOfBirth { get; set; }
        public string? nationality { get; set; }
        public string? birthLocation { get; set; }
        public vmDocumentDetail documentDetail { get; set; }
        public List<vmFlightAddOns> addOns { get; set; }
    }

    public class vmGetAddOnsRS : BaseClass
    {
        public vmGetAddOnsRS()
        {
            ErrorType = 0;
            ErrorMessage = "";
        }
        public vmGetAddOnsRS(int errorType, string? errorMessage)
        {
            ErrorType = errorType;
            ErrorMessage = errorMessage;
        }
        public bool success { get; set; }
        public string? errorMessage { get; set; }
        public vmJourneysWithAvailableAddOns data { get; set; }
    }

    public class vmJourneysWithAvailableAddOns
    {
        public List<vmFlightAddOns> journeysWithAvailableAddOnsOptions { get; set; }
    }

    public class vmFlightAddOns
    {
        public List<vmAvaliableAddOns> segmentsWithAvailableAddOns { get; set; }
        public vmAddOns availableAddOnsOptions { get; set; }
    }


    public class vmAvaliableAddOns
    {
        public vmAddOnsSegment segment { get; set; }
        public vmAddOns availableAddOnsOptions { get; set; }
    }

    public class vmAddOnsSegment
    {
        public string? sourceAirport { get; set; }
        public string? destinationAirport { get; set; }
        public string? departureDate { get; set; }
        public string? marketingAirline { get; set; }
        public string? operatingAirline { get; set; }
        public string? seatClass { get; set; }
    }

    public class vmDocumentDetail
    {
        public string? issuingCountry { get; set; }
        public string? documentNo { get; set; }
        public string? expirationDate { get; set; }
        public string? issuanceDate { get; set; }
        public string? documentType { get; set; }
    }
}
