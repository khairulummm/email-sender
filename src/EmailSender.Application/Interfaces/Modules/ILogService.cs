using DataIntegration.Domain.Entities.TBGAPPHFIRE141.TBIGDataIntegration;
using DataIntegration.Domain.Models.ViewModels;
using DataIntegration.Infrastructure.Data;

namespace DataIntegration.Application.Interfaces.Modules
{
    public interface ILogService
    {
        Task SaveLogJobRequest(dtPostLogJobRequest post);
        Task SaveLogError(logError data);
        Task SaveLogError(IUnitOfWork uow, logError data);
    }
}
