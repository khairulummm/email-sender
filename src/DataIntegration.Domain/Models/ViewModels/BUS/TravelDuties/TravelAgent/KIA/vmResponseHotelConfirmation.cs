using DataIntegration.Domain.Models.Abstracts;

namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.KIA
{
    public class vmResponseHotelConfirmation : BaseClass
    {
        public vmResponseHotelConfirmation()
        {
            ErrorType = 0;
            ErrorMessage = string.Empty;
            Confirmation = new vmResponseHotelConfirmationData();
        }

        public vmResponseHotelConfirmation(int errorType, string? errorMessage)
        {
            ErrorType = errorType;
            ErrorMessage = errorMessage;
            Confirmation = new vmResponseHotelConfirmationData();
        }

        public bool IsPriceChange { get; set; }
        public vmResponseHotelConfirmationData Confirmation { get; set; }
        public string? AvailableRooms { get; set; }
        public bool AllowIssued { get; set; }
        public bool MustAttachFileForGuaranteed { get; set; }
        public bool IsError { get; set; }
        public string? Message { get; set; }
        public string? ErrorCode { get; set; }
        public string? Warning { get; set; }
    }

    public class vmResponseHotelConfirmationData
    {
        public vmResponseHotelConfirmationData()
        {
            HotelMessages = new List<vmResponseHotelConfirmationHotelMessage>();
            CancelPolicySummaries = new List<string>();
            PriceDetails = new List<vmResponseSearchHotelRoomDetail>();
        }
        public string? ConfirmationId { get; set; }
        public string? ProviderCode { get; set; }
        public string? ProviderHotelCode { get; set; }
        public string? ProviderRoomHash { get; set; }
        public string? RoomKey { get; set; }
        public string? HotelKey { get; set; }
        public string? HotelName { get; set; }
        public bool Available { get; set; }
        public string? Address { get; set; }
        public double StarRating { get; set; }
        public string? CountryName { get; set; }
        public string? IsoCountryCode { get; set; }
        public string? CityName { get; set; }
        public string? CityKey { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string? Facsimile { get; set; }
        public string? Phone { get; set; }
        public string? Website { get; set; }
        public string? Email { get; set; }
        public string? GuestPassport { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int TotalNight { get; set; }
        public int CountGuest { get; set; }
        public int CountChild { get; set; }
        public int CountRoom { get; set; }
        public string? RoomName { get; set; }
        public string? BreakfastName { get; set; }
        public bool IncludeBreakfast { get; set; }
        public string? Currency { get; set; }
        public double RequestedPrice { get; set; }
        public double TotalPrice { get; set; }
        public bool IsPriceChange { get; set; }
        public double DifferencePrice { get; set; }
        public bool IsPromoFare { get; set; }
        public string? PromoFareFor { get; set; }
        public bool IsFullCharge { get; set; }
        public bool IsGuaranteedBooking { get; set; }
        public DateTime CancelLimit { get; set; }
        public bool RoomAvailable { get; set; }
        public bool AllowsSpecialRequests { get; set; }
        public string? ForeignCurrency { get; set; }
        public decimal? ForeignCurrencyRate { get; set; }
        public string? Version { get; set; }
        public string? SubProviderCode { get; set; }
        public List<vmResponseHotelConfirmationHotelMessage> HotelMessages { get; set; }
        public List<string> CancelPolicySummaries { get; set; }
        public List<vmResponseSearchHotelRoomDetail> PriceDetails { get; set; }
        public string? StayDateDisplay { get; set; }
        public string? CancelLimitDisplay { get; set; }
        public double MarkupTotal { get; set; }
        public double ServiceFee { get; set; }
        public string? CompanyCode { get; set; }
        public string? CompanyName { get; set; }
        public double PpnFee { get; set; }
        public double AdminFee { get; set; }
        public double HiddenProfit { get; set; }
        public string? RateCode { get; set; }
        public string? RateName { get; set; }
        public bool IsHotelServiceFeeIncluded { get; set; }
        //public List<object> HotelServiceFeeIncludedList { get; set; }
        //public object BedType { get; set; }
    }

    public class vmResponseHotelConfirmationHotelMessage
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Text { get; set; }
        public bool DateSpecified { get; set; }
    }
}