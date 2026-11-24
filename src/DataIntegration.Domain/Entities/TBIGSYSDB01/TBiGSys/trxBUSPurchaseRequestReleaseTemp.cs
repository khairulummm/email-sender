using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys
{
    [Table("trxBUSPurchaseRequestReleaseTemp")]
    public class trxBUSPurchaseRequestReleaseTemp
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(20)]
        public string Type { get; set; }

        [Required]
        [MaxLength(30)]
        public string PurchReqID { get; set; }

        [Required]
        [MaxLength(30)]
        public string RequestID { get; set; }

        [Required]
        public int LineNumber { get; set; }

        [Required]
        [MaxLength(20)]
        public string ItemID { get; set; }

        [Required]
        [MaxLength(1500)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "numeric(28,2)")]
        public decimal PurchQty { get; set; }

        [Required]
        [MaxLength(30)]
        public string PurchUnit { get; set; }

        [Required]
        [Column(TypeName = "numeric(28,2)")]
        public decimal PurchPrice { get; set; }

        [Required]
        [MaxLength(3)]
        public string CurrencyCode { get; set; }

        [Required]
        [MaxLength(20)]
        public string ProjID { get; set; }

        [Required]
        [MaxLength(50)]
        public string AuditUser { get; set; }

        [Required]
        [MaxLength(30)]
        public string ActionApprove { get; set; }

        [Required]
        [MaxLength(1500)]
        public string Remarks { get; set; }

        [Required]
        [MaxLength(50)]
        public string ToUser { get; set; }

        [Required]
        [MaxLength(50)]
        public string DraftCORNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string ContractNumber { get; set; }

        [Required]
        public int Payment { get; set; }

        [Required]
        [MaxLength(50)]
        public string Vendor { get; set; }

        [Required]
        [MaxLength(50)]
        public string ItemIDDetail { get; set; }

        [Required]
        [MaxLength(20)]
        public string SONumber { get; set; }

        [Required]
        [Column(TypeName = "numeric(28,2)")]
        public decimal PercentageUtilized { get; set; }

        [Required]
        public bool IsGenerate { get; set; }

        public DateTime? GenerateDate { get; set; }

        [Required]
        [MaxLength(20)]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [MaxLength(20)]
        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
