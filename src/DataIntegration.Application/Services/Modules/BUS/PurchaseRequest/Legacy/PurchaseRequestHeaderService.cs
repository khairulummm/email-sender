using DataIntegration.Application.Interfaces.Entities.HTBGDBS03.TBG_Sys;
using DataIntegration.Application.Interfaces.Modules.BUS.PurchaseRequest.Legacy;
using DataIntegration.Domain.Entities.HTBGDBS03.TBG_Sys;
using DataIntegration.Infrastructure.Data;

namespace DataIntegration.Application.Services.Modules.BUS.PurchaseRequest.Legacy
{
    public class PurchaseRequestHeaderService(IUnitOfWorkFactory unitOfWorkFactory, IServiceProvider serviceProvider)
        : IPurchaseRequestHeaderService
    {
        private readonly ITR_PurchReq_HeaderService _trPurchReq_HeaderService;

        public PurchaseRequestHeaderService(IUnitOfWorkFactory unitOfWorkFactory,
                                  IServiceProvider serviceProvider,
                                  ITR_PurchReq_HeaderService trPurchReq_HeaderService
                                  ) : this(unitOfWorkFactory, serviceProvider)
        {
            _trPurchReq_HeaderService = trPurchReq_HeaderService;
        }

        public async Task CreatePurchaseRequest(TR_PurchReq_Header data)
        {
            try
            {
                await _trPurchReq_HeaderService.AddAsync(data);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
