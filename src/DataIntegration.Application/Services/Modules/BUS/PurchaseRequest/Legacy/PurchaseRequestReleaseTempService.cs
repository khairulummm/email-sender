using DataIntegration.Application.Interfaces.Entities.TBIGSYSDB01.TBiGSys;
using DataIntegration.Application.Interfaces.Modules.BUS.PurchaseRequest.Legacy;
using DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys;
using DataIntegration.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Application.Services.Modules.BUS.PurchaseRequest.Legacy
{
    public class PurchaseRequestReleaseTempService(IUnitOfWorkFactory unitOfWorkFactory, IServiceProvider serviceProvider): IPurchaseRequestReleaseTempService
    {
        private readonly ItrxBUSPurchaseRequestReleaseTempService _trxBUSPurchaseRequestReleaseTempService;

        public PurchaseRequestReleaseTempService(IUnitOfWorkFactory unitOfWorkFactory,
                                  IServiceProvider serviceProvider,
                                  ItrxBUSPurchaseRequestReleaseTempService trxBUSPurchaseRequestReleaseTempService
                                  ) : this(unitOfWorkFactory, serviceProvider)
        {
            _trxBUSPurchaseRequestReleaseTempService = trxBUSPurchaseRequestReleaseTempService;
        }

        public async Task CreatePurchaseRequestReleaseTemp(trxBUSPurchaseRequestReleaseTemp data) 
        {
            try
            {
                await _trxBUSPurchaseRequestReleaseTempService.AddAsync(data);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
