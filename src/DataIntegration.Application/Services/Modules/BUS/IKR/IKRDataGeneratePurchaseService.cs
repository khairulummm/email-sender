using DataIntegration.Application.Interfaces.Entities.TBIGSYSDB01.TBGFTTH;
using DataIntegration.Application.Interfaces.Modules.BUS.IKR;
using DataIntegration.Domain.Entities.TBIGSYSDB01.TBGFTTH;
using DataIntegration.Infrastructure.Data;

namespace DataIntegration.Application.Services.Modules.BUS.IKR
{
    public class IKRDataGeneratePurchaseService(IUnitOfWorkFactory unitOfWorkFactory, IServiceProvider serviceProvider)
        : IIKRDataGeneratePurchaseService
    {
        private readonly IvwBUSIKRDataPurchaseService _vwBUSIKRDataPurchaseService;
        private readonly IvwBUSIKRGeneratePurchase_POService _vwBUSIKRGeneratePurchase_POService;
        private readonly IvwBUSIKRGeneratePurchase_ReleasePlanService _vwBUSIKRGeneratePurchase_ReleasePlanService;

        public IKRDataGeneratePurchaseService(IUnitOfWorkFactory unitOfWorkFactory,
                                   IServiceProvider serviceProvider,
                                   IvwBUSIKRDataPurchaseService vwBUSIKRDataPurchaseService,
                                   IvwBUSIKRGeneratePurchase_POService vwBUSIKRGeneratePurchase_POService,
                                   IvwBUSIKRGeneratePurchase_ReleasePlanService vwBUSIKRGeneratePurchase_ReleasePlanService
                                   ) : this(unitOfWorkFactory, serviceProvider)
        {
            _vwBUSIKRDataPurchaseService = vwBUSIKRDataPurchaseService;
            _vwBUSIKRGeneratePurchase_POService = vwBUSIKRGeneratePurchase_POService;
            _vwBUSIKRGeneratePurchase_ReleasePlanService = vwBUSIKRGeneratePurchase_ReleasePlanService;
        }

        public async Task<List<vwBUSIKRDataPurchase>> GetListDataPurchase()
        {
            try
            {
                var data = await _vwBUSIKRDataPurchaseService.GetListAsync();
                return data.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<vwBUSIKRDataPurchase>> GetListDataPurchase(vwBUSIKRDataPurchase param)
        {
            try
            {
                var data = await _vwBUSIKRDataPurchaseService.GetListAsync(filter: x => x.WOTypeID == param.WOTypeID);
                return data.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<vwBUSIKRGeneratePurchase_PO>> GetListGeneratePurchase_PO()
        {
            try
            {
                var data = await _vwBUSIKRGeneratePurchase_POService.GetListAsync();
                return data.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<vwBUSIKRGeneratePurchase_ReleasePlan>> GetListGeneratePurchase_ReleasePlan()
        {
            try
            {
                var data = await _vwBUSIKRGeneratePurchase_ReleasePlanService.GetListAsync();
                return data.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
