using DataIntegration.Domain.Models.Abstracts;

namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.KIA
{
    public class vmResponseFlightIssued : BaseClass
    {
        public vmResponseFlightIssued()
        {
            ErrorType = 0;
            ErrorMessage = string.Empty;
        }

        public vmResponseFlightIssued(int errorType, string? errorMessage)
        {
            ErrorType = errorType;
            ErrorMessage = errorMessage;
        }

        public string? TicketConfirmStatus { get; set; }
        public string? Error { get; set; }
        public string? Message { get; set; }

    }
}
