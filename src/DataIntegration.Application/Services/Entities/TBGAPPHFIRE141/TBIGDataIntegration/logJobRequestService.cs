using DataIntegration.Application.Interfaces.Entities.TBGAPPHFIRE141.TBIGDataIntegration;
using DataIntegration.Domain.Entities.TBGAPPHFIRE141.TBIGDataIntegration;
using DataIntegration.Infrastructure.Data;

namespace DataIntegration.Application.Services.Entities.TBGAPPHFIRE141.TBIGDataIntegration
{
    public class logJobRequestService(IUnitOfWorkFactory unitOfWorkFactory, IServiceProvider serviceProvider)
       : BaseService<logJobRequest>(unitOfWorkFactory, serviceProvider, "TBGAPPHFIRE141_DataIntegration"), IlogJobRequestService
    {
    }
}
