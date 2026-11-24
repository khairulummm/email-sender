using DataIntegration.Application.Interfaces.Entities.TBIGSADB01.TBGSecureAccess;
using DataIntegration.Domain.Entities.TBIGSADB01.TBGSecureAccess;
using DataIntegration.Infrastructure.Data;

namespace DataIntegration.Application.Services.Entities.TBIGSADB01.TBGSecureAccess
{
    public class mstEndpointTravelokaService(IUnitOfWorkFactory unitOfWorkFactory, IServiceProvider serviceProvider)
        : BaseService<mstEndpointTraveloka>(unitOfWorkFactory, serviceProvider, "TBIGSADB01_TBGSecureAccess"), ImstEndpointTravelokaService
    {
    }
}
