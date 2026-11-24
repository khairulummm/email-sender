using DataIntegration.Application.Interfaces.Entities.TBIGSADB01.TBGSecureAccess;
using DataIntegration.Domain.Entities.TBIGSADB01.TBGSecureAccess;
using DataIntegration.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Application.Services.Entities.TBIGSADB01.TBGSecureAccess
{
    public class vwRootEndpointKiaService(IUnitOfWorkFactory unitOfWorkFactory, IServiceProvider serviceProvider)
        : BaseService<vwRootEndpointKia>(unitOfWorkFactory, serviceProvider, "TBIGSADB01_TBGSecureAccess"), IvwRootEndpointKiaService
    {
    }
}
