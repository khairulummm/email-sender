using DataIntegration.Domain.Models.ViewModels.Workflow;
using DataIntegration.Domain.Models.ViewModels.Workflow.parameter;

namespace DataIntegration.Application.Interfaces.Modules.Workflow
{
    public interface IWorkflowService
    {
        Task<vmWorkflowApiResponse<vmWorkflowAssignmentProcess>> GetAssignmentProcessAsync(string moduleTransactionID);
        Task<vmWorkflowApiResponse<vmWorkflow>> SubmitApprovalAsync<T>(vmWorkflowData<T> data, string userID = null);
    }
}
