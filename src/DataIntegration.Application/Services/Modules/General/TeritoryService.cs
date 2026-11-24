using DataIntegration.Application.Interfaces.Entities.TBIGSYSDB01.TBiGSys;
using DataIntegration.Application.Interfaces.Modules.General;
using DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys;
using DataIntegration.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Application.Services.Modules.General
{
    public class TeritoryService(IUnitOfWorkFactory unitOfWorkFactory, IServiceProvider serviceProvider) : ITeritoryService
    {
        private readonly IidxTeritoryService _idxTeritoryService;

        public TeritoryService(IUnitOfWorkFactory unitOfWorkFactory,
                           IServiceProvider serviceProvider,
                           IidxTeritoryService idxTeritoryService
           ) : this(unitOfWorkFactory, serviceProvider)
        {
            _idxTeritoryService = idxTeritoryService;
        }

        public async Task<List<idxTeritory>> GetTeritoryByResidenceIDs(int[] ResidenceIDs)
        {
            try
            {
                var data = await _idxTeritoryService.GetListAsync(filter: x=> ResidenceIDs.Contains(x.ResidenceID));
                return data.ToList();

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
