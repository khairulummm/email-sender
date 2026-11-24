using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataIntegration.Domain.Entities.HTBGDBS03.TBG_Sys
{
    [Table("TR_PurchReq_Header", Schema = "tbg")]
    public class TR_PurchReq_Header
    {
        [Key]
        [MaxLength(30)]
        public string RequestID { get; set; }

        [MaxLength(30)]
        public string? PurchReqId { get; set; }

        [MaxLength(250)]
        public string? PurchReqName { get; set; }

        [MaxLength(60)]
        public string? StatusPR { get; set; }

        [MaxLength(250)]
        public string? DeliveryAddress { get; set; }

        [MaxLength(10)]
        public string? DeliveryZipCode { get; set; }

        [MaxLength(30)]
        public string? DeliveryCountry { get; set; }

        [MaxLength(30)]
        public string? DeliveryCountryRegionID { get; set; }

        [MaxLength(30)]
        public string? DeliveryState { get; set; }

        [MaxLength(70)]
        public string? DeliveryName { get; set; }

        [MaxLength(70)]
        public string? DeliveryCity { get; set; }

        [MaxLength(250)]
        public string? DeliveryStreet { get; set; }

        [MaxLength(30)]
        public string? Dimension { get; set; }

        [MaxLength(30)]
        public string? Dimension2 { get; set; }

        [MaxLength(30)]
        public string? Dimension3 { get; set; }

        [MaxLength(20)]
        public string? SubmittedBy { get; set; }

        public DateTime? SubmittedDatetime { get; set; }

        [MaxLength(50)]
        public string? AttachmentId { get; set; }

        public int? StepPR { get; set; }

        public DateTime? TanggalSelesaiProject { get; set; }

        [MaxLength(20)]
        public string? NamaDiketahui { get; set; }

        [MaxLength(20)]
        public string? NamaKonfirmasi { get; set; }

        [MaxLength(20)]
        public string? NamaDisetujui { get; set; }

        [MaxLength(20)]
        public string? ItemId { get; set; }

        [MaxLength(30)]
        public string? PurchReqType { get; set; }

        [MaxLength(50)]
        public string? LogNumber { get; set; }

        public DateTime? LogDateOpen { get; set; }

        [MaxLength(20)]
        public string? LogSiteId { get; set; }

        [MaxLength(100)]
        public string? LogSiteName { get; set; }

        [MaxLength(20)]
        public string? LogSPVId { get; set; }

        [MaxLength(70)]
        public string? LogSPVName { get; set; }

        [MaxLength(20)]
        public string? LogCustId { get; set; }

        public bool? Insurance { get; set; }

        [MaxLength(20)]
        public string? Operator { get; set; }

        [MaxLength(150)]
        public string? BOQId { get; set; }

        public DateTime? ModifiedDatetime { get; set; }

        [MaxLength(20)]
        public string? ModifiedBy { get; set; }

        public DateTime? CreateDatetime { get; set; }

        [MaxLength(20)]
        public string? CreatedBy { get; set; }

        [MaxLength(4)]
        public string? DataAreaId { get; set; }

        public DateTime? StartPeriode { get; set; }

        public DateTime? EndPeriode { get; set; }

        [Column(TypeName = "text")]
        public string? Remarks { get; set; }

        [MaxLength(30)]
        public string? ReferencePR { get; set; }

        [MaxLength(50)]
        public string? OnBehalf { get; set; }

        [MaxLength(50)]
        public string? Action { get; set; }

        [MaxLength(50)]
        public string? ReceivedBy { get; set; }

        public DateTime? ReceivedDateTime { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string? RemarkReceive { get; set; }

        [MaxLength(50)]
        public string? ApprovedBy { get; set; }

        public DateTime? ApprovedDateTime { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string? RemarkApproval { get; set; }

        public DateTime? PrintDatetime { get; set; }

        public bool? IsRegional { get; set; }

        public DateTime? ApproveHO { get; set; }

        [MaxLength(50)]
        public string? ApproveBy { get; set; }

        [Column(TypeName = "text")]
        public string? RemarksApproveRegional { get; set; }

        [MaxLength(50)]
        public string? MaintenanceRutinType { get; set; }

        [MaxLength(50)]
        public string? POReference { get; set; }

        [MaxLength(50)]
        public string? VendorMaintenanceRutin { get; set; }

        [MaxLength(50)]
        public string? ProjectType { get; set; }

        public bool? IsStandard { get; set; }

        [MaxLength(50)]
        public string? PLN { get; set; }

        [MaxLength(50)]
        public string? STIP { get; set; }

        [MaxLength(2)]
        public string? IsGenerate { get; set; }

        [MaxLength(100)]
        public string? AddworkType { get; set; }

        [MaxLength(10)]
        public string? DeptId { get; set; }

        [MaxLength(50)]
        public string? SPK_Number { get; set; }

        public long? AppHeaderID { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        public bool IsOverBudget { get; set; } = false;
    }
}
