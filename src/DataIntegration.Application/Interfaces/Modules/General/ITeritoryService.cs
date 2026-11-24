using DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Application.Interfaces.Modules.General
{
    public interface ITeritoryService
    {
        Task<List<idxTeritory>> GetTeritoryByResidenceIDs(int[] ResidenceIDs);
    }
}
