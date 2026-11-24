using DataIntegration.Application.Interfaces.Entities.TBIGSYSDB01.TBiGSys;
using DataIntegration.Application.Interfaces.Handlers;
using DataIntegration.Application.Interfaces.Modules;
using DataIntegration.Application.Interfaces.Modules.MessageBroker;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using TBIG_e_Tender.Domain.Entities.TBIGSYSDB01.TBIGETender;
using DataIntegration.Application.Model;

namespace DataIntegration.Application.Services.Handlers.ETender.Tender.QnA
{
    public class QnAHandler : IMessageHandler
    {
        private readonly IMessagePublisher _publisher;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly DateTime _dtNow = DateTime.Now;
        public QnAHandler(IMessagePublisher publisher, IServiceScopeFactory scopeFactory)
        {
            _publisher = publisher;
            _scopeFactory = scopeFactory;
        }

        public async Task HandleAsync(string message)
        {
            using var scope = _scopeFactory.CreateScope();

            var data = JsonConvert.DeserializeObject<List<TenderQnADetail>>(message);
            if (data == null || data.Count == 0) return;

            var qnaDetailSvc = scope.ServiceProvider.GetRequiredService<ItrxPRCETenderQnADetailService>();

            foreach (var item in data)
            {
                try
                {
                    var exist = await qnaDetailSvc.GetCountAsync(x => x.QuestionID == item.QuestionID).ConfigureAwait(false);
                    if (exist == 0)
                    {
                        var entity = new Domain.Entities.TBIGSYSDB01.TBiGSys.trxPRCETenderQnADetail
                        {
                            trxPRCETenderQnAID = item.TenderQnAID,
                            QuestionID = item.QuestionID,
                            Question = item.Question,
                            IsSync = true,
                            UpdatedBy = "Data Integration",
                            UpdatedDate = _dtNow
                        };
                        await qnaDetailSvc.AddAsync(entity).ConfigureAwait(false);
                        Console.WriteLine($"[QnAHandler] Created ID: {item.ID}");
                    }

                    item.IsSync = true;
                    item.UpdatedBy = "Data Integration";
                    item.UpdatedDate = _dtNow;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[QnAHandler] ERROR ID {item.ID}: {ex}");
                }
            }

            Console.WriteLine($"[QnA] Processing: {message}");
            var update = JsonConvert.SerializeObject(data);
            await Task.Run(() => _publisher.Publish("tender.qnadetail.status", update));
            await Task.CompletedTask;
        }
    }
}
