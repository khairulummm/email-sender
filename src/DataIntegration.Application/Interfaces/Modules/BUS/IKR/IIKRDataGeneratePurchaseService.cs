using DataIntegration.Domain.Entities.TBIGSYSDB01.TBGFTTH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Application.Interfaces.Modules.BUS.IKR
{
    public interface IIKRDataGeneratePurchaseService
    {
        Task<List<vwBUSIKRDataPurchase>> GetListDataPurchase();
        Task<List<vwBUSIKRDataPurchase>> GetListDataPurchase(vwBUSIKRDataPurchase param);
        Task<List<vwBUSIKRGeneratePurchase_PO>> GetListGeneratePurchase_PO();
        Task<List<vwBUSIKRGeneratePurchase_ReleasePlan>> GetListGeneratePurchase_ReleasePlan();
    }
}
