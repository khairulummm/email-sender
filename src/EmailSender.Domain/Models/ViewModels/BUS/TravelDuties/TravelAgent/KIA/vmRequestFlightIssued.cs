using DataIntegration.Domain.Models.Abstracts;

namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.KIA
{
    public class vmRequestFlightIssued : BaseClass
    {
        public vmRequestFlightIssued()
        {
            ErrorType = 0;
            ErrorMessage = string.Empty;
        }

        public vmRequestFlightIssued(int errorType, string? errorMessage)
        {
            ErrorType = errorType;
            ErrorMessage = errorMessage;
        }
        public string? PnrId { get; set; }
        public string? CallbackUri { get; set; }
    }
}
