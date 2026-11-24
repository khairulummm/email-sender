using System.ComponentModel.DataAnnotations;

namespace DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys
{
    public class uspPRCSPHNonShoppingListNonNetworkGetHeader
    {
        [Key]
        public long? ID { get; set; }
        public long? DocumentID { get; set; }
        public long? ModuleTransactionID { get; set; }

        public long? MasterWorkTypeID { get; set; }
        public string? MasterWorkType { get; set; }

        public string? RequestNumber { get; set; }
        public string? ProjectName { get; set; }

        public string? BudgetPrice { get; set; }

        public decimal? ValueBudgetPrice { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string? BudgetApprovalDocumentFileName { get; set; }
        public string? BudgetApprovalDocumentOriginalFileName { get; set; }
        public string? BudgetApprovalDocumentPath { get; set; }
        public string? BudgetApprovalDocumentContent { get; set; }

        public string? APDFileName { get; set; }
        public string? APDOriginalFileName { get; set; }
        public string? APDPath { get; set; }
        public string? APDContent { get; set; }

        public string? BOQDocumentFileName { get; set; }
        public string? BOQDocumentOriginalFileName { get; set; }
        public string? BOQDocumentPath { get; set; }
        public string? BOQDocumentContent { get; set; }

        public int? CurrentStatusApprovalID { get; set; }
        public int? LastStatusApprovalID { get; set; }
        public string? AssignmentStatusCode { get; set; }

        public string? Requestor { get; set; }

        public long? WinnerAssignVendorID { get; set; }
        public string? WinnerVendorID { get; set; }

        public string? MinimumTotalSPHPrice { get; set; }

        public decimal? ValueMinimumTotalSPHPrice { get; set; }

        public bool? IsSummary { get; set; }
        public bool? IsShowSubmitMitra { get; set; }
    }

}
