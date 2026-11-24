using DataIntegration.Domain.Entities.TBIGSYSDB01.TBGFTTH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Application.Interfaces.Modules.BUS.IKR
{
    public interface IIKRReleasePlanService
    {
        Task UpdateReleasePlanBulky(List<trxASMFTTHPOIKRReleasePlan> data);
    }
}
