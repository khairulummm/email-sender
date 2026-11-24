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
    public class mstEndpointKiaService(IUnitOfWorkFactory unitOfWorkFactory, IServiceProvider serviceProvider)
    : BaseService<mstEndpointKia>(unitOfWorkFactory, serviceProvider, "TBIGSADB01_TBGSecureAccess"), ImstEndpointKiaService
    {
    }
}
