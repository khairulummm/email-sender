using DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties;
using DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent;

namespace DataIntegration.Application.Interfaces.Modules.BUS.TravelDuties
{
    public interface ITravelDutiesService
    {
        Task<vmTravelDutiesBookingOTAStatus> BookingOTAFromJson(dtPostBookingOTA param);
        Task SendEmail(vmTravelDutiesBookingOTAStatus bookResult, string schedullerID);
        Task TestEmail(dtPostBookingOTA param);
    }
}
