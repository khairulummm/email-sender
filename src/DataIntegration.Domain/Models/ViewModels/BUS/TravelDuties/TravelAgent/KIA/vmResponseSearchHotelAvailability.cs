using DataIntegration.Domain.Models.Abstracts;

namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.KIA
{
    public class vmResponseSearchHotelAvailability : BaseClass
    {
        public vmResponseSearchHotelAvailability()
        {
            ErrorType = 0;
            ErrorMessage = string.Empty;

            Stars = new List<vmResponseSearchHotelStars>();
            Areas = new List<vmResponseSearchHotelAreas>();
            Hotels = new List<vmResponseSearchHotel>();
        }

        public vmResponseSearchHotelAvailability(int errorType, string? errorMessage)
        {
            ErrorType = errorType;
            ErrorMessage = errorMessage;

            Stars = new List<vmResponseSearchHotelStars>();
            Areas = new List<vmResponseSearchHotelAreas>();
            Hotels = new List<vmResponseSearchHotel>();
        }

        public int Count { get; set; }
        public int MaxPage { get; set; }
        public bool AllowIssued { get; set; }
        public bool IsShowSupplier { get; set; }
        public string? CorrelationId { get; set; }
        public string? Message { get; set; }
        public string? ErrorCode { get; set; }
        public string? Warning { get; set; }

        public List<vmResponseSearchHotelStars> Stars { get; set; }
        public List<vmResponseSearchHotelAreas> Areas { get; set; }
        public List<vmResponseSearchHotel> Hotels { get; set; }
    }

    public class vmResponseSearchHotelStars
    {
        public int Rating { get; set; }
        public int Count { get; set; }
    }

    public class vmResponseSearchHotelAreas
    {
        public string? Area { get; set; }
        public int Count { get; set; }
    }

    public class vmResponseSearchHotelPackage : BaseClass
    {
        public vmResponseSearchHotelPackage()
        {
            ErrorType = 0;
            ErrorMessage = string.Empty;
            Hotels = new List<vmResponseSearchHotel>();
        }

        public vmResponseSearchHotelPackage(int errorType, string? errorMessage)
        {
            ErrorType = errorType;
            ErrorMessage = errorMessage;
            Hotels = new List<vmResponseSearchHotel>();
        }
        public string? CorrelationId { get; set; }

        public List<vmResponseSearchHotel> Hotels { get; set; }
    }

    public class vmResponseSearchHotel : BaseClass
    {
        public vmResponseSearchHotel()
        {
            Rooms = new List<vmResponseSearchHotelRoom>();
        }
        public string? HotelKey { get; set; }
        public string? HotelName { get; set; }
        public string? ChainCode { get; set; }
        public string? ChainName { get; set; }
        public string? ProviderCode { get; set; }
        public string? ProviderHotelCode { get; set; }
        public decimal StarRating { get; set; }
        public string? IsoCountryCode { get; set; }
        public string? CountryName { get; set; }
        public string? CityKey { get; set; }
        public string? CityName { get; set; }
        public string? Area { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string? Address { get; set; }
        public string? MapImageUri { get; set; }
        public string? Phone { get; set; }
        public string? Facsimile { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        public string? ImageUri { get; set; }
        public string? ThumbUri { get; set; }
        public int Status { get; set; }
        public string? Currency { get; set; }
        public decimal CurrencyRate { get; set; }
        public decimal LowestRoomPrice { get; set; }
        public decimal PricePerRoomNight { get; set; }
        public int OrderPriority { get; set; }
        public List<string> Facilities { get; set; }
        public List<vmResponseSearchHotelRoom> Rooms { get; set; }
        public double AveragePrice { get; set; }
        public bool HavePromoFare { get; set; }
        public string? InlineView { get; set; }
    }

    public class vmResponseSearchHotelRoom
    {
        public vmResponseSearchHotelRoom()
        {
            PriceDetails = new List<vmResponseSearchHotelRoomDetail>();
        }

        public string? ProviderCode { get; set; }
        public string? RoomKey { get; set; }
        public string? RoomHash { get; set; }
        public string? RoomName { get; set; }
        public string? RoomSubText { get; set; }
        public string? RateCode { get; set; }
        public string? RateName { get; set; }
        public string? MealType { get; set; }
        public string? MealTypeName { get; set; }
        public bool IncludeBreakfast { get; set; }
        public string? Currency { get; set; }
        public decimal TotalPrice { get; set; }
        public int OrderPriority { get; set; }
        public int Status { get; set; }
        public bool IsPromoFare { get; set; }
        public string? PromoFareFor { get; set; }
        public string? SubProviderCode { get; set; }
        public List<vmResponseSearchHotelRoomDetail> PriceDetails { get; set; }
        //public AdditionalPrice AdditionalPrice { get; set; }
        public decimal AveragePrice { get; set; }
        public bool HideRemarkHotelForSupplier { get; set; }
    }

    public class vmResponseSearchHotelRoomDetail
    {
        public vmResponseSearchHotelRoomDetail()
        {
            RoomTypePrice = new vmResponseSearchHotelRoomType();
        }

        public int NightIndex { get; set; }
        public int CountAdult { get; set; }
        public int CountChild { get; set; }
        public int CountInfant { get; set; }
        public int TotalRoom { get; set; }
        public double TotalPrice { get; set; }
        public vmResponseSearchHotelRoomType RoomTypePrice { get; set; }
    }

    public class vmResponseSearchHotelRoomType
    {
        public vmResponseSearchHotelRoomType()
        {
            single = new vmResponseSearchHotelRoomTypePrice();
            @double = new vmResponseSearchHotelRoomTypePrice();
            twin = new vmResponseSearchHotelRoomTypePrice();
            triple = new vmResponseSearchHotelRoomTypePrice();
            quad = new vmResponseSearchHotelRoomTypePrice();
        }

        public vmResponseSearchHotelRoomTypePrice single { get; set; }
        public vmResponseSearchHotelRoomTypePrice @double { get; set; }
        public vmResponseSearchHotelRoomTypePrice twin { get; set; }
        public vmResponseSearchHotelRoomTypePrice triple { get; set; }
        public vmResponseSearchHotelRoomTypePrice quad { get; set; }
    }

    public class vmResponseSearchHotelRoomTypePrice
    {
        public string? TypeCode { get; set; }
        public string? TypeName { get; set; }
        public int CountRoom { get; set; }
        public double PricePerRoom { get; set; }
    }
}
