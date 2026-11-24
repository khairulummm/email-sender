using DataIntegration.Domain.Enums.BUS.TravelDuties;

namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.Traveloka
{
    public class dtPostSubmitApiTraveloka
    {
        public TravelokaCredentialName CredentialName { get; set; }
        public TravelokaRootCode RootName { get; set; }
        public TravelokaEndpointCode EndpointName { get; set; }
    }
}
