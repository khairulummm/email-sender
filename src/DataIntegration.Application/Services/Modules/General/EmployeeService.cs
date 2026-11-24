using DataIntegration.Application.Interfaces.Entities.HTBGDBS03.HR_TBG;
using DataIntegration.Application.Interfaces.Modules.General;
using DataIntegration.Domain.Entities.HTBGDBS03.HR_TBG;
using DataIntegration.Infrastructure.Data;
using System.Linq.Expressions;

namespace DataIntegration.Application.Services.Modules.General
{
    public class EmployeeService(IUnitOfWorkFactory unitOfWorkFactory, IServiceProvider serviceProvider) : IEmployeeService
    {
        private readonly IMF_EMPLOYEEService _mfEmployeeService;

        public EmployeeService(IUnitOfWorkFactory unitOfWorkFactory,
                           IServiceProvider serviceProvider,
                           IMF_EMPLOYEEService mfEmployeeService
           ) : this(unitOfWorkFactory, serviceProvider)
        {
            _mfEmployeeService = mfEmployeeService;
        }

        public async Task<MF_EMPLOYEE> GetEmployee(MF_EMPLOYEE post)
        {
            try
            {
                Expression<Func<MF_EMPLOYEE, bool>> filter = x => true;
                if (!string.IsNullOrEmpty(post.Employ_Id))
                    filter = x => x.Employ_Id == post.Employ_Id;
                if (!string.IsNullOrEmpty(post.Employ_Id_TBGSYS))
                    filter = x => x.Employ_Id_TBGSYS == post.Employ_Id_TBGSYS;

                var data = await _mfEmployeeService.GetListAsync(filter);
                return data?.FirstOrDefault();

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
