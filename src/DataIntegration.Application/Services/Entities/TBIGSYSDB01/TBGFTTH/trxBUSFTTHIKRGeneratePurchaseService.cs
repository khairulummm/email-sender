using DataIntegration.Application.Interfaces.Entities.TBIGSYSDB01.TBGFTTH;
using DataIntegration.Domain.Entities.TBIGSYSDB01.TBGFTTH;
using DataIntegration.Infrastructure.Data;

namespace DataIntegration.Application.Services.Entities.TBIGSYSDB01.TBGFTTH
{
    public class trxBUSFTTHIKRGeneratePurchaseService(IUnitOfWorkFactory unitOfWorkFactory, IServiceProvider serviceProvider)
        : BaseService<trxBUSFTTHIKRGeneratePurchase>(unitOfWorkFactory, serviceProvider, "TBIGSYSDB01_TBGFTTH"), ItrxBUSFTTHIKRGeneratePurchaseService
    {
    }
}
