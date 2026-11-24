using DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys;

namespace DataIntegration.Application.Interfaces.Modules.BUS.SPH.NonNetwork
{
    public interface INegotiationLogService
    {
        Task AddLogNegotiationAsync(trxPRCSPHNonShoppingListNonNetworkNegotiation data, IServiceProvider serviceProvider);
    }
}
