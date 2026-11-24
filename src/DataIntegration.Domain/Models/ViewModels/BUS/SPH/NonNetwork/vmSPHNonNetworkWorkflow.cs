using DataIntegration.Domain.Models.Abstracts;

namespace DataIntegration.Domain.Models.ViewModels.BUS.SPH.NonNetwork
{
    public class vmSPHNonNetworkWorkflow : BaseClass
    {
        public vmSPHNonNetworkWorkflow()
        {
            this.ErrorType = 0;
            this.ErrorMessage = null;
        }
        public vmSPHNonNetworkWorkflow(int errorType, string errorMessage)
        {
            this.ErrorType = errorType;
            this.ErrorMessage = errorMessage;
        }
        public long? ModuleTransactionID { get; set; }
        public long? TransactionModuleID { get; set; }
        public string CoreID { get; set; }
        public string ParticipantID { get; set; }
        public string? Requestor { get; set; }
        public DateTime? DateApprove { get; set; }
        public string AssignmentStatusCode { get; set; }
        public string StatusCode { get; set; }
        public string AssignmentBeforeStatusCode { get; set; }
        public string AssignmentStatusDecisionCode { get; set; }
        public string DecisionCode { get; set; }
        public string Remarks { get; set; }
        public string IsNeedAlternativeVendor { get; set; }
        public string IsNeedNegotiation { get; set; }
        public decimal? BudgetRequest { get; set; }
        public decimal? PriceFinalNego { get; set; }
        public string UserID { get; set; }

    }
}
