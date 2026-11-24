namespace DataIntegration.Domain.Models.ViewModels.Workflow.parameter
{
    public class vmWorkflowVariablePurchaseOrder : vmWorkflowVariable
    {
        public string PurchaseOrderID { get; set; }
        public int PurchaseTypeID { get; set; }
        public bool? IsAutoPR { get; set; }
    }
}
