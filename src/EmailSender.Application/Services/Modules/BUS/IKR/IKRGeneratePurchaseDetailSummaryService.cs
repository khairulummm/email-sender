using DataIntegration.Application.Interfaces.Entities.TBIGSYSDB01.TBGFTTH;
using DataIntegration.Application.Interfaces.Modules.BUS.IKR;
using DataIntegration.Application.Services.Entities.TBIGSYSDB01.TBGFTTH;
using DataIntegration.Domain.Entities.TBIGSYSDB01.TBGFTTH;
using DataIntegration.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Application.Services.Modules.BUS.IKR
{
    public class IKRGeneratePurchaseDetailSummaryService(IUnitOfWorkFactory unitOfWorkFactory, IServiceProvider serviceProvider)
        : IIKRGeneratePurchaseDetailSummaryService
    {
        private readonly IvwBUSIKRGeneratePurchaseDetailSummaryService _vwBUSIKRGeneratePurchaseDetailSummary;
        private readonly ItrxBUSFTTHIKRGeneratePurchaseDetailSummaryService _trxBUSFTTHIKRGeneratePurchaseDetailSummary;

        public IKRGeneratePurchaseDetailSummaryService(IUnitOfWorkFactory unitOfWorkFactory,
                                   IServiceProvider serviceProvider,
                                   IvwBUSIKRGeneratePurchaseDetailSummaryService vwBUSIKRGeneratePurchaseDetailSummary,
                                   ItrxBUSFTTHIKRGeneratePurchaseDetailSummaryService trxBUSFTTHIKRGeneratePurchaseDetailSummary
                                   ) : this(unitOfWorkFactory, serviceProvider)
        {
            _vwBUSIKRGeneratePurchaseDetailSummary = vwBUSIKRGeneratePurchaseDetailSummary;
            _trxBUSFTTHIKRGeneratePurchaseDetailSummary = trxBUSFTTHIKRGeneratePurchaseDetailSummary;
        }

        public async Task<List<vwBUSIKRGeneratePurchaseDetailSummary>> GetDataToGeneratePurchaseDetailSummary(int woTypeID, int[] GeneratePurchaseIDs = null)
        {
            try
            {
                GeneratePurchaseIDs ??= Array.Empty<int>();

                Expression<Func<vwBUSIKRGeneratePurchaseDetailSummary, bool>> filter = x => x.WOTypeID == woTypeID;
                if (GeneratePurchaseIDs.Length > 0 )
                    filter = x => x.WOTypeID == woTypeID && GeneratePurchaseIDs.Contains(x.GeneratePurchaseID);

                var data = await _vwBUSIKRGeneratePurchaseDetailSummary.GetListAsync(filter);
                return data.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<trxBUSFTTHIKRGeneratePurchaseDetailSummary>> GetListGeneratePurchaseDetailSummary(int[] GeneratePurchaseIDs = null)
        {
            try
            {
                GeneratePurchaseIDs ??= Array.Empty<int>();

                Expression<Func<trxBUSFTTHIKRGeneratePurchaseDetailSummary, bool>> filter = x => true;
                if (GeneratePurchaseIDs.Length > 0)
                    filter = x => GeneratePurchaseIDs.Contains(x.trxBUSFTTHIKRGeneratePurchaseID);

                var data = await _trxBUSFTTHIKRGeneratePurchaseDetailSummary.GetListAsync(filter);
                return data.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task CreateGeneratePurchaseDetailSummaryBulky(List<trxBUSFTTHIKRGeneratePurchaseDetailSummary> data)
        {
            try
            {
                await _trxBUSFTTHIKRGeneratePurchaseDetailSummary.AddBulkAsync(data);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
