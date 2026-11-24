using DataIntegration.Application.Interfaces.Entities.TBIGSYSDB01.TBiGSys;
using DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys;
using DataIntegration.Infrastructure.Data;

namespace DataIntegration.Application.Services.Entities.TBIGSYSDB01.TBiGSys
{
    public class trxPRCAuctionSystemAssignVendorOfferingPriceService(IUnitOfWorkFactory unitOfWorkFactory, IServiceProvider serviceProvider)
        : BaseService<trxPRCAuctionSystemAssignVendorOfferingPrice>(unitOfWorkFactory, serviceProvider), ItrxPRCAuctionSystemAssignVendorOfferingPriceService
    {
    }
}
