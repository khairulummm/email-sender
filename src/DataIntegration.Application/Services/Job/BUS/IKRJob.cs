using DataIntegration.Application.Interfaces.Modules;
using DataIntegration.Application.Interfaces.Modules.BUS.IKR;
using DataIntegration.Domain.Models.ViewModels;
using DataIntegration.Domain.Models.ViewModels.BUS.IKR;
using DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TickerQ.Utilities.Base;
using TickerQ.Utilities.Models;

namespace DataIntegration.Application.Services.Job.BUS
{
    public class IKRJob
    {
        private readonly IServiceProvider _serviceProvider;

        public IKRJob(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [TickerFunction(functionName: "GenerateAllStep")]
        public async Task GenerateAllStep(TickerFunctionContext<dtPostIKR> ctx, CancellationToken token)
        {
            var stopWatch = Stopwatch.StartNew();
            try
            {
                Console.Clear();
                var param = ctx.Request;
                param.SchedullerID = Convert.ToString(ctx.Id);
                var service = _serviceProvider.GetRequiredService<IIKRService>();
                await service.GenerateAllStep(param);

                Console.WriteLine($"✅ Job executed with schedullerID: {param.SchedullerID}");
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


        [TickerFunction(functionName: "GenerateStep1")]
        public async Task GenerateStep1(TickerFunctionContext<dtPostIKR> ctx, CancellationToken token)
        {
            var stopWatch = Stopwatch.StartNew();
            try
            {
                Console.Clear();
                var param = ctx.Request;
                param.SchedullerID = Convert.ToString(ctx.Id);
                var service = _serviceProvider.GetRequiredService<IIKRService>();
                await service.Step1(param);

                Console.WriteLine($"✅ Job executed with schedullerID: {param.SchedullerID}");
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


        [TickerFunction(functionName: "GenerateStep2")]
        public async Task GenerateStep2(TickerFunctionContext<dtPostIKR> ctx, CancellationToken token)
        {
            var stopWatch = Stopwatch.StartNew();
            try
            {
                Console.Clear();
                var param = ctx.Request;
                param.SchedullerID = Convert.ToString(ctx.Id);
                var service = _serviceProvider.GetRequiredService<IIKRService>();
                await service.Step2(param);

                Console.WriteLine($"✅ Job executed with schedullerID: {param.SchedullerID}");
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


        [TickerFunction(functionName: "GenerateStep3")]
        public async Task GenerateStep3(TickerFunctionContext<dtPostIKR> ctx, CancellationToken token)
        {
            var stopWatch = Stopwatch.StartNew();
            try
            {
                Console.Clear();
                var param = ctx.Request;
                param.SchedullerID = Convert.ToString(ctx.Id);
                var service = _serviceProvider.GetRequiredService<IIKRService>();
                await service.Step3();

                Console.WriteLine($"✅ Job executed with schedullerID: {param.SchedullerID}");
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
