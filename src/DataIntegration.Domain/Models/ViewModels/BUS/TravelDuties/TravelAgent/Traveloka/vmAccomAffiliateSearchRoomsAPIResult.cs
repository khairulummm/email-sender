using DataIntegration.Domain.Models.Abstracts;

namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.Traveloka
{
    public class vmAccomAffiliateSearchRoomsAPIResult : BaseClass
    {
        public vmAccomAffiliateSearchRoomsAPIResult()
        {
            ErrorType = 0;
            ErrorMessage = "";
        }
        public vmAccomAffiliateSearchRoomsAPIResult(int errorType, string? errorMessage)
        {
            ErrorType = errorType;
            ErrorMessage = errorMessage;
        }

        public string? propertyId { get; set; }
        public string? status { get; set; }
        public vmAccomAffiliatePropertySummary propertySummary { get; set; }
        public vmAccomAffiliatePropertyDetailBase propertyDetail { get; set; }
        public List<vmAccomAffiliateImageWithAdditionInfo> propertyImages { get; set; }
        public List<vmAccomAffiliatePropertyAmenity> propertyAmenities { get; set; }
        public List<vmAccomAffiliateAPIRoom> rooms { get; set; }
    }
}
