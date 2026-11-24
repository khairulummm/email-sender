using DataIntegration.Application.Extensions;
using DataIntegration.Application.Interfaces.Entities.TBIGSYSDB01.TBiGSys;
using DataIntegration.Application.Interfaces.Modules.BUS.SPH.NonNetwork;
using DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys;
using Microsoft.Extensions.Logging;

namespace DataIntegration.Application.Services.Modules.BUS.SPH.NonNetwork
{
    public class NegotiationLogService : INegotiationLogService
    {
        private readonly IlogPRCSPHNonShoppingListNonNetworkNegotiationService _logNegoService;
        private readonly ILogger<NegotiationLogService> _logger;

        public NegotiationLogService(IlogPRCSPHNonShoppingListNonNetworkNegotiationService logNegoService, ILogger<NegotiationLogService> logger)
        {
            _logNegoService = logNegoService;
            _logger = logger;
        }

        public async Task AddLogNegotiationAsync(trxPRCSPHNonShoppingListNonNetworkNegotiation data, IServiceProvider serviceProvider)
        {
            try
            {
                var logNego = new logPRCSPHNonShoppingListNonNetworkNegotiation()
                {
                    trxPRCSPHNonShoppingListNonNetworkNegotiationID = data.ID,
                    trxPRCSPHNonShoppingListNonNetworkAssignVendorID = data.trxPRCSPHNonShoppingListNonNetworkAssignVendorID,
                    trxPRCSPHNonShoppingListNonNetworkWorkTypeID = data.trxPRCSPHNonShoppingListNonNetworkWorkTypeID,
                    mstPRCSPHNonShoppingListNonNetworkNegoStatusID = data.mstPRCSPHNonShoppingListNonNetworkNegoStatusID,
                    mstPRCSPHNonShoppingListNonNetworkPICTypeID = data.mstPRCSPHNonShoppingListNonNetworkPICTypeID,
                    RequestorSubmitPriceBy = data.RequestorSubmitPriceBy,
                    RequestorSubmitPriceDate = data.RequestorSubmitPriceDate,
                    RequestPricePerUnit = data.RequestPricePerUnit,
                    TBGSubmitPriceBy = data.TBGSubmitPriceBy,
                    TBGSubmitPriceDate = data.TBGSubmitPriceDate,
                    TBGPrice = data.TBGPrice,
                    VendorSubmitPriceDate = data.VendorSubmitPriceDate,
                    VendorPrice = data.VendorPrice,
                    CreatedBy = data.CreatedBy,
                    CreatedDate = data.CreatedDate,
                    UpdatedBy = data.UpdatedBy,
                    UpdatedDate = data.UpdatedDate,
                };
                await _logNegoService.AddAsync(logNego).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                await _logger.LogException(serviceProvider, ex);
                throw;
            }
        }
    }
}
