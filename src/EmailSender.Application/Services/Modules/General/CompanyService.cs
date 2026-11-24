using DataIntegration.Application.Interfaces.Entities.HTBGDBS03.TBG_Sys;
using DataIntegration.Application.Interfaces.Modules.General;
using DataIntegration.Domain.Entities.HTBGDBS03.TBG_Sys;
using DataIntegration.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Application.Services.Modules.General
{
    public class CompanyService(IUnitOfWorkFactory unitOfWorkFactory, IServiceProvider serviceProvider) : ICompanyService
    {
        private readonly IMF_CompanyService _mfCompanyService;

        public CompanyService(IUnitOfWorkFactory unitOfWorkFactory,
                           IServiceProvider serviceProvider,
                           IMF_CompanyService mfCompanyService
           ) : this(unitOfWorkFactory, serviceProvider)
        {
            _mfCompanyService = mfCompanyService;
        }


        public async Task<MF_Company> GetCompany(string CompanyID)
        {
            try
            {
                var data = await _mfCompanyService.GetListAsync(filter: x=> x.CompanyId == CompanyID);
                return data?.FirstOrDefault();

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
