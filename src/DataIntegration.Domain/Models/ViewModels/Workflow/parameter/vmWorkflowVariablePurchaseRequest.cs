namespace DataIntegration.Domain.Models.ViewModels.Workflow.parameter
{
    public class vmWorkflowVariablePurchaseRequest : vmWorkflowVariable
    {
        public string PurchReqID { get; set; }
        public string ApplicantID { get; set; }
        public decimal? PercentageUtilize { get; set; }
        public int? OverBudgetCounter { get; set; }
        public bool? IsProject { get; set; }
        public string ReceiveBy { get; set; }
        public string PONumber { get; set; }
        public bool? IsLegacy { get; set; }
        public bool? IsAuto { get; set; }
        public bool? IsPrint { get; set; }
    }
}
