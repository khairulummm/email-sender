using DataIntegration.Domain.Entities.HTBGDBS03.TBG_Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Application.Interfaces.Modules.BUS.PurchaseRequest.Legacy
{
    public interface IPurchaseRequestHeaderService
    {
        Task CreatePurchaseRequest(TR_PurchReq_Header data);
    }
}
