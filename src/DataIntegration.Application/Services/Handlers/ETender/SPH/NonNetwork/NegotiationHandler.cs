using DataIntegration.Application.DTOs.ETender.SPH.NonNetwork;
using DataIntegration.Application.Extensions;
using DataIntegration.Application.Interfaces.Handlers;
using DataIntegration.Application.Interfaces.Modules.BUS.SPH.NonNetwork;
using DataIntegration.Application.Interfaces.Modules.MessageBroker;
using DataIntegration.Application.Interfaces.Modules.Workflow;
using DataIntegration.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace DataIntegration.Application.Services.Handlers.ETender.SPH.NonNetwork
{
    public class NegotiationHandler : IMessageHandler
    {
        private readonly IMessagePublisher _publisher;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<NegotiationHandler> _logger;

        public NegotiationHandler(IMessagePublisher publisher, IServiceScopeFactory scopeFactory, ILogger<NegotiationHandler> logger)
        {
            _publisher = publisher;
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        public async Task HandleAsync(string message)
        {
            using var scope = _scopeFactory.CreateScope();

            try
            {
                var uow = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                
                var transactionService = scope.ServiceProvider.GetRequiredService<INegotiationTransactionService>();
                var logService = scope.ServiceProvider.GetRequiredService<INegotiationLogService>();
                var tokenService = scope.ServiceProvider.GetRequiredService<IAssignVendorTokenService>();
                var workflowService = scope.ServiceProvider.GetRequiredService<IWorkflowService>();
                var negotiationWorkflowService = scope.ServiceProvider.GetRequiredService<INegotiationWorkflowService>();

                var dataInput = JsonConvert.DeserializeObject<List<SPHNonShoppingListNonNetworkNegotiation>>(message);

                foreach (var item in dataInput)
                {
                    await uow.BeginTransactionAsync();

                    try
                    {
                        //Update VendorPrice & NegoStatusID
                        var dataNego = await transactionService.UpdateNegotiationAsync(item, scope.ServiceProvider).ConfigureAwait(false);

                        //Insert to log
                        await logService.AddLogNegotiationAsync(dataNego, scope.ServiceProvider).ConfigureAwait(false);

                        //Update sync
                        item.IsSync = true;
                        item.SyncDate = DateTime.Now;

                        //Update token vendor
                        await tokenService.UpdateTokenVendorAsync(dataNego.trxPRCSPHNonShoppingListNonNetworkAssignVendorID, scope.ServiceProvider).ConfigureAwait(false);

                        await uow.CommitAsync();

                        //Update status header
                        await negotiationWorkflowService.GenerateApprovalNegotiationAsync(item, scope.ServiceProvider).ConfigureAwait(false);
                    }
                    catch (Exception ex)
                    {
                        await uow.RollbackAsync();
                        await _logger.LogException(scope.ServiceProvider, ex);

                        continue;
                    }
                }

                Console.WriteLine($"[Negotiation] Processing: {message}");
                var update = JsonConvert.SerializeObject(dataInput);
                await Task.Run(() => _publisher.Publish("sphnonnetwork.negotiation.status", update));
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await _logger.LogException(scope.ServiceProvider, ex);
            }
        }
    }
}
