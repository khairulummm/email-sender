using DataIntegration.Application.Extensions;
using DataIntegration.Application.Interfaces.Entities.TBIGSYSDB01.TBiGSys;
using DataIntegration.Application.Interfaces.Modules.BUS.SPH.NonNetwork;
using Microsoft.Extensions.Logging;

namespace DataIntegration.Application.Services.Modules.BUS.SPH.NonNetwork
{
    public class AssignVendorTokenService : IAssignVendorTokenService
    {
        private readonly ItrxPRCSPHNonShoppingListNonNetworkAssignVendorTokenService _vendorTokenService;
        private readonly ILogger<AssignVendorTokenService> _logger;

        public AssignVendorTokenService(ItrxPRCSPHNonShoppingListNonNetworkAssignVendorTokenService vendorTokenService, ILogger<AssignVendorTokenService> logger)
        {
            _vendorTokenService = vendorTokenService;
            _logger = logger;
        }

        public async Task UpdateTokenVendorAsync(long assignVendorId, IServiceProvider serviceProvider)
        {
            try
            {
                var tokenVendor = (await _vendorTokenService.GetListAsync(filter: x => x.trxPRCSPHNonShoppingListNonNetworkAssignVendorID == assignVendorId).ConfigureAwait(false)).FirstOrDefault();
                tokenVendor.IsActive = false;
                tokenVendor.UpdatedBy = "DataIntegration";
                tokenVendor.UpdatedDate = DateTime.Now;
                await _vendorTokenService.UpdateAsync(tokenVendor).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                await _logger.LogException(serviceProvider, ex);
                throw;
            }
        }
    }
}
