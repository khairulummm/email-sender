namespace DataIntegration.Domain.Models.ViewModels.Workflow.parameter
{
    public class vmWorkflowData<T>
    {
        public string AppID { get; set; }
        public string ModuleCode { get; set; }
        public string CoreID { get; set; }
        public string UserID { get; set; }
        public T Variable { get; set; }
    }
}
