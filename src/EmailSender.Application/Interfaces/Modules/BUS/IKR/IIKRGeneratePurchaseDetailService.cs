using DataIntegration.Domain.Entities.TBIGSYSDB01.TBGFTTH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Application.Interfaces.Modules.BUS.IKR
{
    public interface IIKRGeneratePurchaseDetailService
    {
        Task<List<vwBUSIKRGeneratePurchaseDetail>> GetDataToGeneratePurchaseDetail();
        Task CreateGeneratePurchaseDetailBulky(List<trxBUSFTTHIKRGeneratePurchaseDetail> data);
    }
}
