namespace DataIntegration.Domain.Models.ViewModels.Workflow
{
    public class vmWorkflowAssignmentProcess
    {
        public string TransactionApplicationModuleID { get; set; }
        public string StatusCode { get; set; }
        public string AssignmentCode { get; set; }
        public string[] ParticipantID { get; set; }
        public string MessageValidation { get; set; }
        public string ErrorType { get; set; }
    }
}
