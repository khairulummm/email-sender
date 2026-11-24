using DataIntegration.Domain.Entities.TBIGSYSDB01.TBGFTTH;

namespace DataIntegration.Application.Interfaces.Modules.BUS.IKR
{
    public interface IIKRGeneratePurchaseDetailSummaryService
    {
        Task<List<vwBUSIKRGeneratePurchaseDetailSummary>> GetDataToGeneratePurchaseDetailSummary(int woTypeID, int[] GeneratePurchaseIDs = null);
        Task<List<trxBUSFTTHIKRGeneratePurchaseDetailSummary>> GetListGeneratePurchaseDetailSummary(int[] GeneratePurchaseIDs = null);
        Task CreateGeneratePurchaseDetailSummaryBulky(List<trxBUSFTTHIKRGeneratePurchaseDetailSummary> data);
    }
}
