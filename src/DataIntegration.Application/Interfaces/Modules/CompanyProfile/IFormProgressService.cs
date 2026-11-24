using DataIntegration.Application.DTOs.VendorRegistration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Application.Interfaces.Modules.CompanyProfile
{
    public interface IFormProgressService
    {
        Task<FormProgress> GetByCompanyIdAsync(int companyId);
        Task UpdateAsync(FormProgress formProgress);
    }
}
