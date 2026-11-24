using DataIntegration.Application.Interfaces.Entities.HTBGDBS03.HR_TBG;
using DataIntegration.Domain.Entities.HTBGDBS03.HR_TBG;
using DataIntegration.Infrastructure.Data;

namespace DataIntegration.Application.Services.Entities.HTBGDBS03.HR_TBG
{
    public class MF_EMPLOYEEService(IUnitOfWorkFactory unitOfWorkFactory, IServiceProvider serviceProvider)
       : BaseService<MF_EMPLOYEE>(unitOfWorkFactory, serviceProvider, "HTBGDBS03_HR_TBG"), IMF_EMPLOYEEService
    {
    }
}
