using DataIntegration.Application.Interfaces.Entities.HTBGDBS03.TBG_Sys;
using DataIntegration.Domain.Entities.HTBGDBS03.TBG_Sys;
using DataIntegration.Infrastructure.Data;

namespace DataIntegration.Application.Services.Entities.HTBGDBS03.TBG_Sys
{
    public class spPurchReq_PRNumberService(IUnitOfWorkFactory unitOfWorkFactory, IServiceProvider serviceProvider)
       : BaseService<spPurchReq_PRNumber>(unitOfWorkFactory, serviceProvider, "HTBGDBS03_TBG_sys"), IspPurchReq_PRNumberService
    {
    }
}
