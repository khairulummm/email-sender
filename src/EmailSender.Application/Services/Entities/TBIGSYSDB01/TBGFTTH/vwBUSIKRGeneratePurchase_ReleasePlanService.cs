using DataIntegration.Application.Interfaces.Entities.TBIGSYSDB01.TBGFTTH;
using DataIntegration.Domain.Entities.TBIGSYSDB01.TBGFTTH;
using DataIntegration.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Application.Services.Entities.TBIGSYSDB01.TBGFTTH
{
    public class vwBUSIKRGeneratePurchase_ReleasePlanService(IUnitOfWorkFactory unitOfWorkFactory, IServiceProvider serviceProvider)
        : BaseService<vwBUSIKRGeneratePurchase_ReleasePlan>(unitOfWorkFactory, serviceProvider, "TBIGSYSDB01_TBGFTTH"), IvwBUSIKRGeneratePurchase_ReleasePlanService
    {
    }
}
