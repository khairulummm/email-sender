using DataIntegration.Application.Interfaces.Entities.TBIGSADB01.TBGSecureAccess;
using DataIntegration.Domain.Entities.TBIGSADB01.TBGSecureAccess;
using DataIntegration.Infrastructure.Data;

namespace DataIntegration.Application.Services.Entities.TBIGSADB01.TBGSecureAccess
{
    public class mstRootTravelokaService(IUnitOfWorkFactory unitOfWorkFactory, IServiceProvider serviceProvider) 
        : BaseService<mstRootTraveloka>(unitOfWorkFactory, serviceProvider, "TBIGSADB01_TBGSecureAccess"),ImstRootTravelokaService
    {
    }
}
