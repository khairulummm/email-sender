using DataIntegration.Application.Interfaces.Scheduller.BUS;
using DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent;
using Microsoft.Extensions.Logging;
using TickerQ.Utilities;
using TickerQ.Utilities.Interfaces.Managers;
using TickerQ.Utilities.Models.Ticker;

namespace DataIntegration.Application.Services.Scheduller.BUS
{
    public class TravelDutiesScheduller : ITravelDutiesScheduller
    {

        private readonly ITimeTickerManager<TimeTicker> _ticker;
        private readonly ILogger<TravelDutiesScheduller> _logger;

        public TravelDutiesScheduller(ITimeTickerManager<TimeTicker> ticker, ILogger<TravelDutiesScheduller> logger)
        {
            _ticker = ticker;
            _logger = logger;
        }

        public async Task<TimeTicker> ScheduleBookingOTAAsync(dtPostBookingOTA param)
        {
            try
            {
                var timeTicker = new TimeTicker()
                {
                    //Execution Time tidak boleh <= CreatedAt
                    Function = "BookingAccommodationTransportation",
                    Request = TickerHelper.CreateTickerRequest(param),
                    ExecutionTime = DateTime.Now.AddSeconds(1),

                    CreatedAt = DateTime.Now
                };
                var result = await _ticker.AddAsync(timeTicker, CancellationToken.None);
                _logger.LogInformation("Scheduling ticker for TravelDutiesID: {TravelDutiesID}", param.TravelDutiesID);
                return result.Result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to schedule ticker for TravelDutiesID: {TravelDutiesID}", param.TravelDutiesID);
                throw;
            }
        }

        public async Task<TimeTicker> TestEmail(dtPostBookingOTA param)
        {
            try
            {
                var timeTicker = new TimeTicker()
                {
                    //Execution Time tidak boleh <= CreatedAt
                    Function = "TestEmail",
                    Request = TickerHelper.CreateTickerRequest<dtPostBookingOTA>(param),
                    ExecutionTime = DateTime.Now.AddSeconds(1),

                    CreatedAt = DateTime.Now
                };
                var result = await _ticker.AddAsync(timeTicker, CancellationToken.None);
                _logger.LogInformation("Scheduling ticker for TravelDutiesID: {TravelDutiesID}", param.TravelDutiesID);
                return result.Result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to schedule ticker for TravelDutiesID: {TravelDutiesID}", param.TravelDutiesID);
                throw;
            }
        }
    }
}
