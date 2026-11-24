using DataIntegration.Domain.Entities.HTBGDBS03.HR_TBG;

namespace DataIntegration.Application.Interfaces.Modules.General
{
    public interface IEmployeeService
    {
        Task<MF_EMPLOYEE> GetEmployee(MF_EMPLOYEE post);
    }
}
