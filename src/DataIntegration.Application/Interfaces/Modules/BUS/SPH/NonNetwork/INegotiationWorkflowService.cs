using DataIntegration.Application.DTOs.ETender.SPH.NonNetwork;

namespace DataIntegration.Application.Interfaces.Modules.BUS.SPH.NonNetwork
{
    public interface INegotiationWorkflowService
    {
        Task GenerateApprovalNegotiationAsync(SPHNonShoppingListNonNetworkNegotiation dataInput, IServiceProvider serviceProvider);
    }
}
