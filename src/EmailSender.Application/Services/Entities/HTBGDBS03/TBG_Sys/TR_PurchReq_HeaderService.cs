using DataIntegration.Application.Interfaces.Entities.HTBGDBS03.TBG_Sys;
using DataIntegration.Domain.Entities.HTBGDBS03.TBG_Sys;
using DataIntegration.Infrastructure.Data;

namespace DataIntegration.Application.Services.Entities.HTBGDBS03.TBG_Sys
{
    public class TR_PurchReq_HeaderService(IUnitOfWorkFactory unitOfWorkFactory, IServiceProvider serviceProvider)
       : BaseService<TR_PurchReq_Header>(unitOfWorkFactory, serviceProvider, "HTBGDBS03_TBG_sys"), ITR_PurchReq_HeaderService
    {
    }
}
