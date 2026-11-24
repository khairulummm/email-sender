using DataIntegration.Application.Interfaces.Scheduller.BUS;
using DataIntegration.Domain.Models.ViewModels.BUS.IKR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TickerQ.Utilities;
using TickerQ.Utilities.Interfaces.Managers;
using TickerQ.Utilities.Models.Ticker;

namespace DataIntegration.Application.Services.Scheduller.BUS
{
    public class IKRScheduller : IIKRScheduller
    {
        private readonly ITimeTickerManager<TimeTicker> _ticker;
        private readonly ILogger<IKRScheduller> _logger;

        public IKRScheduller(ITimeTickerManager<TimeTicker> ticker, ILogger<IKRScheduller> logger)
        {
            _ticker = ticker;
            _logger = logger;
        }

        public async Task<TimeTicker> GenerateAllStep(dtPostIKR param)
        {
            try
            {
                var timeTicker = new TimeTicker()
                {
                    //Execution Time tidak boleh <= CreatedAt
                    Function = "GenerateAllStep",
                    Request = TickerHelper.CreateTickerRequest<dtPostIKR>(param),
                    ExecutionTime = DateTime.Now.AddSeconds(1),

                    CreatedAt = DateTime.Now
                };
                var result = await _ticker.AddAsync(timeTicker, CancellationToken.None);
                _logger.LogInformation("Scheduling ticker for IKR Generate Purchase");
                return result.Result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to schedule ticker for IKR Generate Purchase");
                throw;
            }
        }

        public async Task<TimeTicker> GenerateStep1(dtPostIKR param)
        {
            try
            {
                var timeTicker = new TimeTicker()
                {
                    //Execution Time tidak boleh <= CreatedAt
                    Function = "GenerateStep1",
                    Request = TickerHelper.CreateTickerRequest<dtPostIKR>(param),
                    ExecutionTime = DateTime.Now.AddSeconds(1),

                    CreatedAt = DateTime.Now
                };
                var result = await _ticker.AddAsync(timeTicker, CancellationToken.None);
                _logger.LogInformation("Scheduling ticker for IKR Generate Purchase - Step 1");
                return result.Result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to schedule ticker for IKR Generate Purchase - Step 1");
                throw;
            }
        }

        public async Task<TimeTicker> GenerateStep2(dtPostIKR param)
        {
            try
            {
                var timeTicker = new TimeTicker()
                {
                    //Execution Time tidak boleh <= CreatedAt
                    Function = "GenerateStep2",
                    Request = TickerHelper.CreateTickerRequest<dtPostIKR>(param),
                    ExecutionTime = DateTime.Now.AddSeconds(1),

                    CreatedAt = DateTime.Now
                };
                var result = await _ticker.AddAsync(timeTicker, CancellationToken.None);
                _logger.LogInformation("Scheduling ticker for IKR Generate Purchase - Step 2");
                return result.Result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to schedule ticker for IKR Generate Purchase - Step 2");
                throw;
            }
        }

        public async Task<TimeTicker> GenerateStep3(dtPostIKR param)
        {
            try
            {
                var timeTicker = new TimeTicker()
                {
                    //Execution Time tidak boleh <= CreatedAt
                    Function = "GenerateStep3",
                    Request = TickerHelper.CreateTickerRequest<dtPostIKR>(param),
                    ExecutionTime = DateTime.Now.AddSeconds(1),

                    CreatedAt = DateTime.Now
                };
                var result = await _ticker.AddAsync(timeTicker, CancellationToken.None);
                _logger.LogInformation("Scheduling ticker for IKR Generate Purchase - Step 3");
                return result.Result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to schedule ticker for IKR Generate Purchase - Step 3");
                throw;
            }
        }
    }
}
