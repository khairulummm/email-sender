using DataIntegration.Domain.Models.Abstracts;

namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.KIA
{
    public class vmRequestHotelAvailabilityPage : BaseClass
    {
        public vmRequestHotelAvailabilityPage()
        {
            ErrorType = 0;
            ErrorMessage = string.Empty;
        }

        public vmRequestHotelAvailabilityPage(int errorType, string? errorMessage)
        {
            ErrorType = errorType;
            ErrorMessage = errorMessage;
        }
        public string? CorrelationId { get; set; }
        public string? HotelName { get; set; }
        public string? Area { get; set; }
        public int? Page { get; set; }
        public int? Star { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public string? OrderBy { get; set; }
    }
}
