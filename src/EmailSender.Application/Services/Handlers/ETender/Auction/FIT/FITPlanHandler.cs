using DataIntegration.Application.DTOs.ETender.Auction.FIT;
using DataIntegration.Application.Interfaces.Entities.TBIGSYSDB01.TBiGSys;
using DataIntegration.Application.Interfaces.Handlers;
using DataIntegration.Application.Interfaces.Modules.MessageBroker;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace DataIntegration.Application.Services.Handlers.ETender.Auction.FIT
{
    public class FITPlanHandler : IMessageHandler
	{
        private readonly IMessagePublisher _publisher;
        private readonly IServiceScopeFactory _scopeFactory;
        public FITPlanHandler(IMessagePublisher publisher, IServiceScopeFactory scopeFactory)
        {
            _publisher = publisher;
            _scopeFactory = scopeFactory;
        }

        public async Task HandleAsync(string message)
        {
            using var scope = _scopeFactory.CreateScope();

            var data = JsonConvert.DeserializeObject<List<FITPlanSchedule>>(message);
            //Loop semua ID -> Set Sync Information(status,date)
            var requestService = scope.ServiceProvider.GetRequiredService<ItrxBUSFITRequestService>();
            var requestTokenService = scope.ServiceProvider.GetRequiredService<ItrxBUSFITRequestTokenService>();
            foreach (var item in data)
            {
                try
                {
                    var request = await requestService.GetByPKAsync(item.RequestID).ConfigureAwait(false);
                    var requestToken = (await requestTokenService.GetListAsync(f => f.trxBUSFITRequestID == item.RequestID).ConfigureAwait(false)).FirstOrDefault();
                    if(requestToken != null)
                    {
                        requestToken.IsUsed = true;
                        await requestTokenService.UpdateAsync(requestToken);
                        Console.WriteLine($"[trxBUSFITRequestToken] RequestID {item.RequestID} update.");
                    }
                    if (request != null)
                    {
                        request.PlanDate = item.PlanDate;
                        request.FitAddress = item.FitAddress;
                        request.UpdatedBy = "ETender";
                        request.UpdatedDate = DateTime.Now;
                        request.Remarks = item.Remarks;

                        await requestService.UpdateAsync(request).ConfigureAwait(false);

                        Console.WriteLine($"[FITPlanScheduleHandler] RequestID {item.RequestID} update.");
                    }

                    item.IsSync = true;
                    item.SyncDate = DateTime.Now;
                }
                catch
                {
                }
            }
            Console.WriteLine($"[Offer] Processing: {message}");
            var update = JsonConvert.SerializeObject(data);
            await Task.Run(() => _publisher.Publish("fit.schedule.status", update));
            await Task.CompletedTask;
        }
    }
}
