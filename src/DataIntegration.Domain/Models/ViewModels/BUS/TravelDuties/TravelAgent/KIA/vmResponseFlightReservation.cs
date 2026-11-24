using DataIntegration.Domain.Models.Abstracts;

namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.KIA
{
    public class vmResponseFlightReservation : BaseClass
    {
        public vmResponseFlightReservation()
        {
            ErrorType = 0;
            ErrorMessage = string.Empty;
        }

        public vmResponseFlightReservation(int errorType, string? errorMessage)
        {
            ErrorType = errorType;
            ErrorMessage = errorMessage;
        }

        public string? PnrId { get; set; }
        public string? Message { get; set; }
    }
}
