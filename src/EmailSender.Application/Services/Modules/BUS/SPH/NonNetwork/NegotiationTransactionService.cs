using DataIntegration.Application.DTOs.ETender.SPH.NonNetwork;
using DataIntegration.Application.Extensions;
using DataIntegration.Application.Interfaces.Entities.TBIGSYSDB01.TBiGSys;
using DataIntegration.Application.Interfaces.Modules.BUS.SPH.NonNetwork;
using DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys;
using Microsoft.Extensions.Logging;

namespace DataIntegration.Application.Services.Modules.BUS.SPH.NonNetwork
{
    public class NegotiationTransactionService : INegotiationTransactionService
    {
        private readonly ItrxPRCSPHNonShoppingListNonNetworkNegotiationService _trxNegoService;
        private readonly ILogger<NegotiationTransactionService> _logger;

        public NegotiationTransactionService(ItrxPRCSPHNonShoppingListNonNetworkNegotiationService trxNegoService, ILogger<NegotiationTransactionService> logger)
        {
            _trxNegoService = trxNegoService;
            _logger = logger;
        }

        public async Task<trxPRCSPHNonShoppingListNonNetworkNegotiation> UpdateNegotiationAsync(SPHNonShoppingListNonNetworkNegotiation data, IServiceProvider serviceProvider)
        {
            try
            {
                var trxNego = await _trxNegoService.GetByPKAsync((long)data.SPHNonNetworkWorkTypePriceID).ConfigureAwait(false);
                if (data.IsNegotiation == true)
                {
                    trxNego.mstPRCSPHNonShoppingListNonNetworkNegoStatusID = trxNego.TBGPrice == data.Price ? 4 : 3;
                    trxNego.VendorSubmitPriceDate = data.CreatedDate;
                    trxNego.VendorPrice = data.Price;
                }
                trxNego.mstPRCSPHNonShoppingListNonNetworkPICTypeID = 3; //ETender
                trxNego.UpdatedBy = "ETender";
                trxNego.UpdatedDate = data.CreatedDate;
                await _trxNegoService.UpdateAsync(trxNego).ConfigureAwait(false);

                return trxNego;
            }
            catch (Exception ex)
            {
                await _logger.LogException(serviceProvider, ex);
                throw;
            }
        }
    }
}
