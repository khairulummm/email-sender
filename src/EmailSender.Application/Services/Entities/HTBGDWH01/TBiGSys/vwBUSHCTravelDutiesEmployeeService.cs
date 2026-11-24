using DataIntegration.Application.Interfaces.Entities.HTBGDWH01.TBiGSys;
using DataIntegration.Domain.Entities.HTBGDWH01.TBiGSys;
using DataIntegration.Infrastructure.Data;

namespace DataIntegration.Application.Services.Entities.HTBGDWH01.TBiGSys
{
    public class vwBUSHCTravelDutiesEmployeeService(IUnitOfWorkFactory unitOfWorkFactory, IServiceProvider serviceProvider)
        : BaseService<vwBUSHCTravelDutiesEmployee>(unitOfWorkFactory, serviceProvider, "HTBGDWH01_TBiGSys"), IvwBUSHCTravelDutiesEmployeeService
    {
    }
}
