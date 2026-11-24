using DataIntegration.Domain.Models.Abstracts;

namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.KIA
{
    public class vmResponseHotelDetail : BaseClass
    {
        public vmResponseHotelDetail()
        {
            ErrorType = 0;
            ErrorMessage = string.Empty;
        }

        public vmResponseHotelDetail(int errorType, string? errorMessage)
        {
            ErrorType = errorType;
            ErrorMessage = errorMessage;
        }

        public vmResponseHotelDetailData Data { get; set; }
        public bool IsError { get; set; }
        public string? Message { get; set; }
        public string? ErrorCode { get; set; }
        public string? Warning { get; set; }
    }

    public class vmResponseHotelDetailData
    {
        public vmResponseHotelDetailData()
        {
            Facilities = new List<vmResponseHotelDetailFacility>();
            Images = new List<vmResponseHotelDetailImage>();
            Reviews = new List<vmResponseHotelDetailReview>();
        }

        public string? HotelKey { get; set; }
        public string? HotelName { get; set; }
        public string? ProviderCode { get; set; }
        public string? ProviderHotelCode { get; set; }
        public string? Description { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string? Website { get; set; }
        public string? Address { get; set; }
        public string? Telephone { get; set; }
        public string? Facsimile { get; set; }
        public string? Email { get; set; }
        public List<vmResponseHotelDetailFacility> Facilities { get; set; }
        public List<vmResponseHotelDetailImage> Images { get; set; }
        public List<vmResponseHotelDetailReview> Reviews { get; set; }
    }

    public class vmResponseHotelDetailFacility
    {
        public string? Code { get; set; }
        public string? Description { get; set; }
    }

    public class vmResponseHotelDetailImage
    {
        public string? Description { get; set; }
        public string? ImageUri { get; set; }
        public string? ThumbUri { get; set; }
    }

    public class vmResponseHotelDetailReview
    {
        public string? RelativeTime { get; set; }
        public string? Text { get; set; }
        public string? AuthorName { get; set; }
        public int Rating { get; set; }
        public string? Uri { get; set; }
        public DateTime PostedTime { get; set; }
    }
}







