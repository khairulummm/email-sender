using DataIntegration.Domain.Entities.HTBGDBS03.TBG_Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Application.Interfaces.Modules.General
{
    public interface ICompanyService
    {
        Task<MF_Company> GetCompany(string CompanyID);
    }
}
