using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataIntegration.Domain.Entities.TBIGSYSDB01.TBGFTTH
{
    [Table("trxASMFTTHPOIKRReleasePlan", Schema = "dbo")]
    public class trxASMFTTHPOIKRReleasePlan
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Required]
        [Column("HomepassNumber")]
        [MaxLength(100)]
        public string HomepassNumber { get; set; } = string.Empty;

        [Column("CustomerID")]
        [MaxLength(10)]
        public string? CustomerId { get; set; }

        [Column("WOID")]
        [MaxLength(50)]
        public string? WoId { get; set; }

        [Column("CustomerWOID")]
        [MaxLength(50)]
        public string? CustomerWoId { get; set; }

        [Column("Sonumb")]
        [MaxLength(20)]
        public string? Sonumb { get; set; }

        [Column("SiteID")]
        public int? SiteId { get; set; }

        [Column("Sitename")]
        public int? Sitename { get; set; } // ⚠️ Bisa jadi varchar di database sebenarnya, mohon konfirmasi

        [Column("VendorID")]
        [MaxLength(4)]
        public string? VendorId { get; set; }

        [Column("VendorName")]
        [MaxLength(255)]
        public string? VendorName { get; set; }

        [Column("CompanyID")]
        [MaxLength(2)]
        public string? CompanyId { get; set; }

        [Column("ResidenceName")]
        [MaxLength(100)]
        public string? ResidenceName { get; set; }

        [Column("PurchaseOrderName")]
        [MaxLength(104)]
        public string? PurchaseOrderName { get; set; }

        [Column("WOType")]
        [MaxLength(255)]
        public string? WoType { get; set; }

        [Column("ContractNumber")]
        [MaxLength(255)]
        public string? ContractNumber { get; set; }

        [Column("InstallationDate")]
        public DateTime? InstallationDate { get; set; }

        [Column("InstallationStatus")]
        [MaxLength(200)]
        public string? InstallationStatus { get; set; }

        [Column("PurchaseRequestCreator", TypeName = "varchar(max)")]
        public string? PurchaseRequestCreator { get; set; }

        [Column("PurchaseRequestDiketahui", TypeName = "varchar(max)")]
        public string? PurchaseRequestDiketahui { get; set; }

        [Column("PurchaseRequestDisetujui", TypeName = "varchar(max)")]
        public string? PurchaseRequestDisetujui { get; set; }

        [Column("PurchaseRequestDikonfirmasi", TypeName = "varchar(max)")]
        public string? PurchaseRequestDikonfirmasi { get; set; }

        [Column("PurchaseOrderCreator")]
        [MaxLength(12)]
        public string? PurchaseOrderCreator { get; set; }

        [Column("StatusID")]
        public int? StatusId { get; set; }

        [Required]
        [Column("CreatedBy")]
        [MaxLength(20)]
        public string CreatedBy { get; set; } = string.Empty;

        [Required]
        [Column("CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [Column("UpdatedBy")]
        [MaxLength(20)]
        public string? UpdatedBy { get; set; }

        [Column("UpdatedDate")]
        public DateTime? UpdatedDate { get; set; }

        [Column("WOTypeID")]
        public int? WoTypeId { get; set; }

        [Column("TermPayment")]
        [MaxLength(50)]
        public string? TermPayment { get; set; }

        [Column("ResidenceID")]
        [MaxLength(50)]
        public string? ResidenceId { get; set; }

        [Column("RegionID")]
        [MaxLength(50)]
        public string? RegionId { get; set; }

        [Column("WOStatusID")]
        [MaxLength(50)]
        public string? WoStatusId { get; set; }
    }
}
