using DataIntegration.Application.Interfaces.Entities.TBIGSYSDB01.TBGFTTH;
using DataIntegration.Application.Interfaces.Modules.BUS.IKR;
using DataIntegration.Domain.Entities.TBIGSYSDB01.TBGFTTH;
using DataIntegration.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Application.Services.Modules.BUS.IKR
{
    public class IKRGeneratePurchaseDetailService(IUnitOfWorkFactory unitOfWorkFactory, IServiceProvider serviceProvider)
        : IIKRGeneratePurchaseDetailService
    {
        private readonly IvwBUSIKRGeneratePurchaseDetailService _vwBUSIKRGeneratePurchaseDetailService;
        private readonly ItrxBUSFTTHIKRGeneratePurchaseDetailService _trxBUSFTTHIKRGeneratePurchaseDetailService;

        public IKRGeneratePurchaseDetailService(IUnitOfWorkFactory unitOfWorkFactory,
                                   IServiceProvider serviceProvider,
                                   IvwBUSIKRGeneratePurchaseDetailService vwBUSIKRGeneratePurchaseDetailService,
                                   ItrxBUSFTTHIKRGeneratePurchaseDetailService trxBUSFTTHIKRGeneratePurchaseDetailService
                                   ) : this(unitOfWorkFactory, serviceProvider)
        {
            _vwBUSIKRGeneratePurchaseDetailService = vwBUSIKRGeneratePurchaseDetailService;
            _trxBUSFTTHIKRGeneratePurchaseDetailService = trxBUSFTTHIKRGeneratePurchaseDetailService;
        }

        public async Task<List<vwBUSIKRGeneratePurchaseDetail>> GetDataToGeneratePurchaseDetail()
        {
            try
            {
                var data = await _vwBUSIKRGeneratePurchaseDetailService.GetListAsync();
                return data.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task CreateGeneratePurchaseDetailBulky(List<trxBUSFTTHIKRGeneratePurchaseDetail> data)
        {
            try
            {
                await _trxBUSFTTHIKRGeneratePurchaseDetailService.AddBulkAsync(data);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
