using DataIntegration.Domain.Models.Abstracts;

namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.KIA
{
    public class vmRequestHotelConfirmation : BaseClass
    {
        public vmRequestHotelConfirmation()
        {
            ErrorType = 0;
            ErrorMessage = string.Empty;
        }

        public vmRequestHotelConfirmation(int errorType, string? errorMessage)
        {
            ErrorType = errorType;
            ErrorMessage = errorMessage;
        }

        public string? CorrelationId { get; set; }
        public string? HotelKey { get; set; }
        public string? RoomKey { get; set; }

    }
}
