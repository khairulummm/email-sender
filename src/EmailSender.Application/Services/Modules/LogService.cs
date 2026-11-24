using DataIntegration.Application.Interfaces.Entities.TBGAPPHFIRE141.TBIGDataIntegration;
using DataIntegration.Application.Interfaces.Modules;
using DataIntegration.Domain.Entities.TBGAPPHFIRE141.TBIGDataIntegration;
using DataIntegration.Domain.Models.ViewModels;
using DataIntegration.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DataIntegration.Application.Services.Modules
{
    public class LogService(IUnitOfWorkFactory unitOfWorkFactory, IServiceProvider serviceProvider) : ILogService
    {
        private readonly IlogJobRequestService _logJobRequestService;
        private readonly IlogErrorService _logErrorService;

        public LogService(IUnitOfWorkFactory unitOfWorkFactory,
                                   IServiceProvider serviceProvider,
                                   IlogJobRequestService logJobRequestService,
                                   IlogErrorService logErrorService) : this(unitOfWorkFactory, serviceProvider)
        {
            _logJobRequestService = logJobRequestService;
            _logErrorService = logErrorService;
        }

        public async Task SaveLogJobRequest(dtPostLogJobRequest data)
        {
            try
            {
                var log = new logJobRequest()
                {
                    SchedullerID = data.SchedullerID,
                    Job = data.Job,
                    Method = data.Method,
                    Request = data.Request,
                    Response = data.Response,
                    ExecutionTime = Convert.ToDecimal(data.ExecutionTime),
                    CreatedBy = data.UserID,
                    CreatedDate = DateTime.Now,
                };
                await _logJobRequestService.AddAsync(log);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task SaveLogError(logError data)
        {
            try
            {
                await _logErrorService.AddAsync(data);
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task SaveLogError(IUnitOfWork uow, logError data)
        {
            try
            {
                await _logErrorService.AddAsync(uow, data);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
