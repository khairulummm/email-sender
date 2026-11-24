using DataIntegration.Domain.Models.Abstracts;

namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.Traveloka
{
    public class vmAccomAffiliateSearchRoomAPIResult : BaseClass
    {
        public vmAccomAffiliateSearchRoomAPIResult()
        {
            ErrorType = 0;
            ErrorMessage = "";
        }
        public vmAccomAffiliateSearchRoomAPIResult(int errorType, string? errorMessage)
        {
            ErrorType = errorType;
            ErrorMessage = errorMessage;
        }

        public string? status { get; set; }
        public List<vmAccomAffiliateAPIRoom> MyProperty { get; set; }
    }
}
