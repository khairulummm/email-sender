using DataIntegration.Application.DTOs.VendorRegistration;
using DataIntegration.Application.Interfaces.Modules.CompanyProfile;
using DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys;
using DataIntegration.Infrastructure.Data;
using DataIntegration.Infrastructure.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace DataIntegration.Application.Services.Modules.CompanyProfile
{
    public class FormProgressService : IFormProgressService
    {
        private readonly IUnitOfWorkFactory _uowFactory;

        public FormProgressService(IUnitOfWorkFactory uowFactory)
        {
            _uowFactory = uowFactory;
        }

        public async Task<FormProgress> GetByCompanyIdAsync(int companyId)
        {
            using var uow = _uowFactory.Create("TBGVendorRegistration");
            var repo = uow.GetRepository<FormProgress>();
            var list = await repo.GetListAsync(x => x.CompanyID == companyId).ConfigureAwait(false);
            return list.FirstOrDefault();
        }

        public async Task UpdateAsync(FormProgress formProgress)
        {
            using var uow = _uowFactory.Create("TBGVendorRegistration");
            var repo = uow.GetRepository<FormProgress>();
            repo.Update(formProgress);
            await uow.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}