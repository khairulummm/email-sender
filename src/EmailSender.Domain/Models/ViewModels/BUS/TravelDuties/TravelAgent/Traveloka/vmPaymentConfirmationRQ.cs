using DataIntegration.Domain.Models.Abstracts;

namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.Traveloka
{
    public class vmPaymentConfirmationRQ : BaseClass
    {
        public vmPaymentConfirmationRQ()
        {
            ErrorType = 0;
            ErrorMessage = "";
        }
        public vmPaymentConfirmationRQ(int errorType, string? errorMessage)
        {
            ErrorType = errorType;
            ErrorMessage = errorMessage;
        }
        public string? bookingId { get; set; }
        public string? paymentMethod { get; set; }
    }
}
