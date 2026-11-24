using DataIntegration.Domain.Models.Abstracts;

namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.Traveloka
{
    public class vmAccomAffiliateAPIProperty : BaseClass
    {
        public vmAccomAffiliateAPIProperty()
        {
            ErrorType = 0;
            ErrorMessage = "";
        }
        public vmAccomAffiliateAPIProperty(int errorType, string? errorMessage)
        {
            ErrorType = errorType;
            ErrorMessage = errorMessage;
        }

        public string? propertyId { get; set; }
        public vmAccomAffiliatePropertySummary propertySummary { get; set; }
        public List<vmAccomAffiliateImageWithAdditionInfo> propertyImages { get; set; }
        public vmAccomAffiliateAPIRate cheapestRoom { get; set; }
        public string? cheapestRoomName { get; set; }
        public string? rateKey { get; set; }
    }

}
