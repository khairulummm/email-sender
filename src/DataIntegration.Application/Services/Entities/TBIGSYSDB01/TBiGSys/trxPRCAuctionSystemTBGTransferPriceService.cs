using DataIntegration.Application.Interfaces.Entities.TBIGSYSDB01.TBiGSys;
using DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys;
using DataIntegration.Infrastructure.Data;

namespace DataIntegration.Application.Services.Entities.TBIGSYSDB01.TBiGSys
{
    public class trxPRCAuctionSystemTBGTransferPriceService(IUnitOfWorkFactory unitOfWorkFactory, IServiceProvider serviceProvider)
        : BaseService<trxPRCAuctionSystemTBGTransferPrice>(unitOfWorkFactory, serviceProvider), ItrxPRCAuctionSystemTBGTransferPriceService
    {
    }
}
