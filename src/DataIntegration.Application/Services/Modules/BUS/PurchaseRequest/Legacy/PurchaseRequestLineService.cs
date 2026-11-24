using DataIntegration.Application.Interfaces.Entities.HTBGDBS03.TBG_Sys;
using DataIntegration.Application.Interfaces.Modules.BUS.PurchaseRequest.Legacy;
using DataIntegration.Domain.Entities.HTBGDBS03.TBG_Sys;
using DataIntegration.Infrastructure.Data;

namespace DataIntegration.Application.Services.Modules.BUS.PurchaseRequest.Legacy
{
    public class PurchaseRequestLineService(IUnitOfWorkFactory unitOfWorkFactory, IServiceProvider serviceProvider)
        : IPurchaseRequestLineService
    {
        private readonly ITR_PurchReq_LineService _trPurchReq_LineService;

        public PurchaseRequestLineService(IUnitOfWorkFactory unitOfWorkFactory,
                                  IServiceProvider serviceProvider,
                                  ITR_PurchReq_LineService trPurchReq_LineService
                                  ) : this(unitOfWorkFactory, serviceProvider)
        {
            _trPurchReq_LineService = trPurchReq_LineService;
        }


        public async Task CreatePurchaseRequestLineBulky(List<TR_PurchReq_Line> data)
        {
            try
            {
                await _trPurchReq_LineService.AddBulkAsync(data);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
