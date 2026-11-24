using DataIntegration.Application.DTOs.ETender.SPH.NonNetwork;
using DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys;

namespace DataIntegration.Application.Interfaces.Modules.BUS.SPH.NonNetwork
{
    public interface INegotiationTransactionService
    {
        Task<trxPRCSPHNonShoppingListNonNetworkNegotiation> UpdateNegotiationAsync(SPHNonShoppingListNonNetworkNegotiation data, IServiceProvider serviceProvider);
    }
}
