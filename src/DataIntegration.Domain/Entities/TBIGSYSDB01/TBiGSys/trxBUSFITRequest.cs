using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys
{
    public class trxBUSFITRequest
    {
        [Key]
        public int ID { get; set; }
        public int mstGeneralApprovalAssignmentID { get; set; }
        public string Requestor { get; set; }
        public string TransactionNumber { get; set; }
        public string VendorID { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PICName { get; set; }
        public string PICPhone { get; set; }
        public int MaterialID { get; set; }
        public DateTime? PlanDate { get; set; }
        public string? FitAddress { get; set; }
        public DateTime? ActualDate { get; set; }
        public DateTime? ActualSubmitedDate { get; set; }
        public string? CertificateNumber { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? RequestType { get; set; }
        public string? Remarks { get; set; }
    }

}
