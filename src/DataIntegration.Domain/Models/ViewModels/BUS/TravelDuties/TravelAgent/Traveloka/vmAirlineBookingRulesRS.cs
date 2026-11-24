using DataIntegration.Domain.Models.Abstracts;

namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.Traveloka
{
    public class vmAirlineBookingRulesRS : BaseClass
    {
        public vmAirlineBookingRulesRS()
        {
            ErrorType = 0;
            ErrorMessage = "";
        }
        public vmAirlineBookingRulesRS(int errorType, string? errorMessage)
        {
            ErrorType = errorType;
            ErrorMessage = errorMessage;
        }


        public bool success { get; set; }
        public string? errorMessage { get; set; }
        public vmRules data { get; set; }
    }
    public class vmRules
    {
        public bool requiresBirthDate { get; set; }
        public bool requiresNationality { get; set; }
        public bool requiresId { get; set; }
        public bool requiresDocumentNoForInternational { get; set; }
        public bool requiresDocumentNoForDomestic { get; set; }
    }
}
