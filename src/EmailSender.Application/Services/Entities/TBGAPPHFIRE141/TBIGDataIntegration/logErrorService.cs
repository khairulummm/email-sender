using DataIntegration.Application.Interfaces.Entities.TBGAPPHFIRE141.TBIGDataIntegration;
using DataIntegration.Domain.Entities.TBGAPPHFIRE141.TBIGDataIntegration;
using DataIntegration.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Application.Services.Entities.TBGAPPHFIRE141.TBIGDataIntegration
{
    public class logErrorService(IUnitOfWorkFactory unitOfWorkFactory, IServiceProvider serviceProvider)
       : BaseService<logError>(unitOfWorkFactory, serviceProvider, "TBGAPPHFIRE141_DataIntegration"), IlogErrorService
    {
    }
}
