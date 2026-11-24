using Dapper;
using DataIntegration.Application.Interfaces.Entities.HTBGDBS03.TBG_Sys;
using DataIntegration.Application.Interfaces.Modules.BUS.PurchaseRequest.Legacy;
using DataIntegration.Domain.Entities.HTBGDBS03.TBG_Sys;
using DataIntegration.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Application.Services.Modules.BUS.PurchaseRequest.Legacy
{
    public class GeneratePurchaseRequestNumberService(IUnitOfWorkFactory unitOfWorkFactory, IServiceProvider serviceProvider) : IGeneratePurchaseRequestNumberService
    {
        private readonly IspPurchReq_PRNumberService _spPurchReq_PRNumberService;


        public GeneratePurchaseRequestNumberService(IUnitOfWorkFactory unitOfWorkFactory,
                           IServiceProvider serviceProvider,
                           IspPurchReq_PRNumberService spPurchReq_PRNumberService
           ) : this(unitOfWorkFactory, serviceProvider)
        {
            _spPurchReq_PRNumberService = spPurchReq_PRNumberService;
        }

        public async Task<spPurchReq_PRNumber> GetPurchaseRequestID(string CompanyID)
        {
            try
            {
                return await pExecSPPurchReq_PRNumber("PR", CompanyID);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<spPurchReq_PRNumber> GetRequestID(string CompanyID)
        {
            try
            {
                return await pExecSPPurchReq_PRNumber("Request", CompanyID);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<spPurchReq_PRNumber> pExecSPPurchReq_PRNumber(string Type, string CompanyID)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@f_type", Type ?? (object)DBNull.Value);
                parameters.Add("@f_Company", CompanyID ?? (object)DBNull.Value);

                var result = _spPurchReq_PRNumberService.ExecuteStoredProcedureQuery<spPurchReq_PRNumber>("tbg.spPurchReq_PRNumber", parameters);
                return result?.FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
