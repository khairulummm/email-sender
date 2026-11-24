using DataIntegration.Domain.Models.Abstracts;

namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.Traveloka
{
    public class vmAccomAffiliateSearchListAPIResult : BaseClass
    {
        public vmAccomAffiliateSearchListAPIResult()
        {
            ErrorType = 0;
            ErrorMessage = "";
        }
        public vmAccomAffiliateSearchListAPIResult(int errorType, string? errorMessage)
        {
            ErrorType = errorType;
            ErrorMessage = errorMessage;
        }
        public string? totalProperties { get; set; }
        public string? maximalOffset { get; set; }
        public List<vmAccomAffiliateAPIProperty> properties { get; set; }
    }
}