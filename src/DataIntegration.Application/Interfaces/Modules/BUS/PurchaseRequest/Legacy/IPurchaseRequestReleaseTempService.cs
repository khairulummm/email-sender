using DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Application.Interfaces.Modules.BUS.PurchaseRequest.Legacy
{
    public interface IPurchaseRequestReleaseTempService
    {
        Task CreatePurchaseRequestReleaseTemp(trxBUSPurchaseRequestReleaseTemp data);
    }
}
