using Dapper;
using DataIntegration.Application.Interfaces.Entities.TBIGSYSDB01.TBGFTTH;
using DataIntegration.Application.Interfaces.Modules.BUS.IKR;
using DataIntegration.Domain.Entities.TBIGSYSDB01.TBGFTTH;
using DataIntegration.Domain.Enums.BUS.IKR;
using DataIntegration.Domain.Models.ViewModels.BUS.IKR;
using DataIntegration.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Application.Services.Modules.BUS.IKR
{
    public class IKRGeneratePurchaseService(IUnitOfWorkFactory unitOfWorkFactory, IServiceProvider serviceProvider)
        : IIKRGeneratePurchaseService
    {
        private readonly IuspBUSIKRGeneratePurchaseService _uspBUSIKRGeneratePurchaseService;
        private readonly ItrxBUSFTTHIKRGeneratePurchaseService _trxBUSFTTHIKRGeneratePurchaseService;

        public IKRGeneratePurchaseService(IUnitOfWorkFactory unitOfWorkFactory,
                                   IServiceProvider serviceProvider,
                                   IuspBUSIKRGeneratePurchaseService uspBUSIKRGeneratePurchaseService,
                                   ItrxBUSFTTHIKRGeneratePurchaseService trxBUSFTTHIKRGeneratePurchaseService
                                   ) : this(unitOfWorkFactory, serviceProvider)
        {
            _uspBUSIKRGeneratePurchaseService = uspBUSIKRGeneratePurchaseService;
            _trxBUSFTTHIKRGeneratePurchaseService = trxBUSFTTHIKRGeneratePurchaseService;
        }

        public async Task<List<uspBUSIKRGeneratePurchase>> GetDataToGeneratePurchase(dtPostIKRGeneratePurchase post)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@FTTHIKRGenerateID", post.FTTHIKRGenerateID ?? (object)DBNull.Value);
                parameters.Add("@WOTypeID", post.WOTypeID ?? (object)DBNull.Value);

                var result = _uspBUSIKRGeneratePurchaseService.ExecuteStoredProcedureQuery<uspBUSIKRGeneratePurchase>("dbo.uspBUSIKRGeneratePurchase", parameters);
                return result.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<trxBUSFTTHIKRGeneratePurchase>> GetListGeneratePurchase(trxBUSFTTHIKRGeneratePurchase post) 
        {
            try
            {
                var data = await _trxBUSFTTHIKRGeneratePurchaseService.GetListAsync(filter: x => x.trxBUSFTTHIKRGenerateID == post.trxBUSFTTHIKRGenerateID
                                                                                                &&  x.CompanyID == post.CompanyID 
                                                                                                && x.VendorID == post.VendorID
                                                                                                && x.ResidenceID == post.ResidenceID
                                                                                                && x.CustomerID == post.CustomerID
                                                                                                && x.WOTypeID == post.WOTypeID);

                return data.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task CreateGeneratePurchaseBulky(List<trxBUSFTTHIKRGeneratePurchase> data)
        {
            try
            {
                await _trxBUSFTTHIKRGeneratePurchaseService.AddBulkAsync(data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateGeneratePurchaseBulky(List<trxBUSFTTHIKRGeneratePurchase> data)
        {
            try
            {
                await _trxBUSFTTHIKRGeneratePurchaseService.UpdateBulkAsync(data);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
