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
    public class IKRReleasePlanService(IUnitOfWorkFactory unitOfWorkFactory, IServiceProvider serviceProvider)
        : IIKRReleasePlanService
    {
        private readonly ItrxASMFTTHPOIKRReleasePlanService _trxASMFTTHPOIKRReleasePlanService;

        public IKRReleasePlanService(IUnitOfWorkFactory unitOfWorkFactory,
                                   IServiceProvider serviceProvider,
                                   ItrxASMFTTHPOIKRReleasePlanService trxASMFTTHPOIKRReleasePlanService
                                   ) : this(unitOfWorkFactory, serviceProvider)
        {
            _trxASMFTTHPOIKRReleasePlanService = trxASMFTTHPOIKRReleasePlanService;
        }

        public async Task UpdateReleasePlanBulky(List<trxASMFTTHPOIKRReleasePlan> data)
        {
            try
            {
                await _trxASMFTTHPOIKRReleasePlanService.UpdateBulkAsync(data);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
