using DataIntegration.Application.Interfaces.Modules.BUS.TravelDuties;
using TickerQ.Utilities.Base;
using TickerQ.Utilities.Models;
using Microsoft.Extensions.DependencyInjection;
using DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent;
using System.Text.Json;
using System.Diagnostics;
using DataIntegration.Application.Interfaces.Modules;
using DataIntegration.Domain.Models.ViewModels;
using DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties;
using System.Reflection;

namespace DataIntegration.Application.Services.Job.BUS
{
    public class TravelDutiesJob
    {
        private readonly IServiceProvider _serviceProvider;

        public TravelDutiesJob(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [TickerFunction(functionName: "BookingAccommodationTransportation")]
        public async Task BookingAccommodationTransportation(TickerFunctionContext<dtPostBookingOTA> ctx, CancellationToken token)
        {
            var stopWatch = Stopwatch.StartNew();
            var result = new vmTravelDutiesBookingOTAStatus();
            try
            {
                var param = ctx.Request;
                param.SchedullerID = Convert.ToString(ctx.Id);
                var travelDutiesService = _serviceProvider.GetRequiredService<ITravelDutiesService>();
                result = await travelDutiesService.BookingOTAFromJson(param);
                Console.WriteLine($"Result : {JsonSerializer.Serialize(result)}");

                await travelDutiesService.SendEmail(result, param.SchedullerID);
                Console.WriteLine($"✅ Job executed with input: {param.TravelDutiesID}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace?.ToString());
                throw;
            }
            finally
            {
                stopWatch.Stop();

                var caller = Helper.Helper.GetCallerInfo();
                var log = new dtPostLogJobRequest()
                {
                    SchedullerID = Convert.ToString(ctx.Id),
                    Job = caller.ServiceName,
                    Method = caller.MethodName,
                    Request = JsonSerializer.Serialize(ctx.Request),
                    Response = JsonSerializer.Serialize(result),
                    ExecutionTime = Convert.ToDecimal(stopWatch.Elapsed.TotalSeconds),
                    UserID = "DataIntegration",
                };
                var logService = _serviceProvider.GetRequiredService<ILogService>();
                await logService.SaveLogJobRequest(log);
            }
        }

        [TickerFunction(functionName: "TestEmail")]
        public async Task TestEmail(TickerFunctionContext<dtPostBookingOTA> ctx, 
                                    CancellationToken token)
        {
            var stopWatch = Stopwatch.StartNew();
            try
            {
                var param = ctx.Request;
                param.SchedullerID = Convert.ToString(ctx.Id);
                var travelDutiesService = _serviceProvider.GetRequiredService<ITravelDutiesService>();
                await travelDutiesService.TestEmail(param);

                Console.WriteLine($"✅ Job executed with input: {param.TravelDutiesID}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace?.ToString());
                throw;
            }
            finally
            {
                stopWatch.Stop();

                var caller = Helper.Helper.GetCallerInfo();
                var log = new dtPostLogJobRequest()
                {
                    SchedullerID = Convert.ToString(ctx.Id),
                    Job = caller.ServiceName,
                    Method = caller.MethodName,
                    Request = JsonSerializer.Serialize(ctx.Request),
                    Response = null,
                    ExecutionTime = Convert.ToDecimal(stopWatch.Elapsed.TotalSeconds),
                    UserID = "DataIntegration",
                };
                var logService = _serviceProvider.GetRequiredService<ILogService>();
                await logService.SaveLogJobRequest(log);
            }
        }
    }
}
