using DataIntegration.Domain.Entities.TBIGSYSDB01.TBGFTTH;
using DataIntegration.Domain.Models.ViewModels.BUS.IKR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Application.Interfaces.Modules.BUS.IKR
{
    public interface IIKRGeneratePurchaseService
    {
        Task<List<uspBUSIKRGeneratePurchase>> GetDataToGeneratePurchase(dtPostIKRGeneratePurchase post);
        Task<List<trxBUSFTTHIKRGeneratePurchase>> GetListGeneratePurchase(trxBUSFTTHIKRGeneratePurchase post);
        Task CreateGeneratePurchaseBulky(List<trxBUSFTTHIKRGeneratePurchase> data);
        Task UpdateGeneratePurchaseBulky(List<trxBUSFTTHIKRGeneratePurchase> data);
    }
}
