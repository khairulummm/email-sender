using DataIntegration.Application.DTOs.ETender.Auction.FIT;
using DataIntegration.Application.Interfaces.Entities.TBIGSYSDB01.TBiGSys;
using DataIntegration.Application.Interfaces.Handlers;
using DataIntegration.Application.Interfaces.Modules.MessageBroker;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace DataIntegration.Application.Services.Handlers.ETender.Auction.FIT
{
    public class FITActualHandler : IMessageHandler
	{
        private readonly IMessagePublisher _publisher;
        private readonly IServiceScopeFactory _scopeFactory;
        public FITActualHandler(IMessagePublisher publisher, IServiceScopeFactory scopeFactory)
        {
            _publisher = publisher;
            _scopeFactory = scopeFactory;
        }

        public async Task HandleAsync(string message)
        {
            using var scope = _scopeFactory.CreateScope();

            var data = JsonConvert.DeserializeObject<List<FITActualSchedule>>(message);
            //Loop semua ID -> Set Sync Information(status,date)
            var requestService = scope.ServiceProvider.GetRequiredService<ItrxBUSFITRequestService>();
            var requestTokenActualService = scope.ServiceProvider.GetRequiredService<ItrxBUSFITRequestTokenActualService>();
            foreach (var item in data)
            {
                try
                {
                    var request = await requestService.GetByPKAsync(item.RequestID).ConfigureAwait(false);
                    var requestToken = (await requestTokenActualService.GetListAsync(f => f.trxBUSFITRequestID == item.RequestID).ConfigureAwait(false)).FirstOrDefault();
                    if (requestToken != null)
                    {
                        requestToken.IsUsed = true;
                        await requestTokenActualService.UpdateAsync(requestToken);
                        Console.WriteLine($"[trxBUSFITRequestTokenActual] RequestID {item.RequestID} update.");
                    }
                    if (request != null)
                    {
                        request.ActualDate = item.ActualDate;
                        request.ActualSubmitedDate = item.ActualSubmittedDate;
                        request.UpdatedBy = "ETender";
                        request.UpdatedDate = DateTime.Now;

                        await requestService.UpdateAsync(request).ConfigureAwait(false);

                        Console.WriteLine($"[FITActualScheduleHandler] RequestID {item.RequestID} update.");
                    }

                    item.IsSync = true;
                    item.SyncDate = DateTime.Now;
                }
                catch
                {
                }
            }
            Console.WriteLine($"[Plan] Processing: {message}");
            var update = JsonConvert.SerializeObject(data);
            await Task.Run(() => _publisher.Publish("fit.actual.status", update));
            await Task.CompletedTask;
        }
    }
}
