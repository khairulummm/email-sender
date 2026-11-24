using DataIntegration.Domain.Models.Abstracts;

namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.KIA
{
    public class vmRequestHotelDetail : BaseClass
    {
        public vmRequestHotelDetail()
        {
            ErrorType = 0;
            ErrorMessage = string.Empty;
        }

        public vmRequestHotelDetail(int errorType, string? errorMessage)
        {
            ErrorType = errorType;
            ErrorMessage = errorMessage;
        }

        public string? CorrelationId { get; set; }
        public string? HotelKey { get; set; }
    }
}
