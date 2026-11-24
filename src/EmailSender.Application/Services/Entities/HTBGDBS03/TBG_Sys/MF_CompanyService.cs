using DataIntegration.Application.Interfaces.Entities.HTBGDBS03.TBG_Sys;
using DataIntegration.Domain.Entities.HTBGDBS03.TBG_Sys;
using DataIntegration.Infrastructure.Data;

namespace DataIntegration.Application.Services.Entities.HTBGDBS03.TBG_Sys
{
    public class MF_CompanyService(IUnitOfWorkFactory unitOfWorkFactory, IServiceProvider serviceProvider)
   : BaseService<MF_Company>(unitOfWorkFactory, serviceProvider, "HTBGDBS03_TBG_sys"), IMF_CompanyService
    {
    }
}
