namespace DataIntegration.Domain.Models.ViewModels.Workflow.parameter
{
    public class vmWorkflowEMS : vmWorkflowVariable
    {
        public string ApplicantID { get; set; }
        public string VendorID { get; set; }
        public string TotalAmount { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string RemarkFormInput { get; set; }
        public string IsAllItemStandard { get; set; }
        public string AmountAddWork { get; set; }
        public int mstBUSEMSFlagID { get; set; }
    }
}
