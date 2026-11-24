using DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent;
using TickerQ.Utilities.Models.Ticker;

namespace DataIntegration.Application.Interfaces.Scheduller.BUS
{
    public interface ITravelDutiesScheduller 
    {
        Task<TimeTicker> ScheduleBookingOTAAsync(dtPostBookingOTA param);
        Task<TimeTicker> TestEmail(dtPostBookingOTA param);
    }
}
