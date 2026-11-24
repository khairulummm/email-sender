using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Domain.Entities.TBIGSYSDB01.TBGFTTH
{
    [Table("trxBUSFTTHIKRGeneratePurchase")]
    public class trxBUSFTTHIKRGeneratePurchase
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [ForeignKey(nameof(trxBUSFTTHIKRGenerate))]
        public int trxBUSFTTHIKRGenerateID { get; set; }

        [Required]
        [MaxLength(100)]
        public string HomepassNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string CustomerID { get; set; }

        [Required]
        [MaxLength(50)]
        public string WOID { get; set; }

        [Required]
        [MaxLength(50)]
        public string CustomerWOID { get; set; }

        [MaxLength(50)]
        public string? Sonumb { get; set; }

        [MaxLength(150)]
        public string? SiteID { get; set; }

        [MaxLength(250)]
        public string? Sitename { get; set; }

        [Required]
        [MaxLength(6)]
        public string VendorID { get; set; }

        [Required]
        [MaxLength(6)]
        public string CompanyID { get; set; }

        [Required]
        public int ResidenceID { get; set; }

        [MaxLength(50)]
        public string? PurchaseRequestNumber { get; set; }

        [MaxLength(50)]
        public string? PurchaseOrderNumber { get; set; }

        [MaxLength(5000)]
        public string? PurchaseOrderName { get; set; }

        [Required]
        public int WOTypeID { get; set; }

        [Required]
        public int TermPayment { get; set; }

        [Required]
        [MaxLength(250)]
        public string ContractNumber { get; set; }

        [Required]
        [MaxLength(20)]
        public string PurchaseRequestCreator { get; set; }

        [Required]
        [MaxLength(20)]
        public string PurchaseRequestDiketahui { get; set; }

        [Required]
        [MaxLength(20)]
        public string PurchaseRequestDisetujui { get; set; }

        [Required]
        [MaxLength(20)]
        public string PurchaseRequestDikonfirmasi { get; set; }

        [Required]
        [MaxLength(20)]
        public string PurchaseOrderCreator { get; set; }

        [Required]
        [MaxLength(20)]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [MaxLength(20)]
        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        // 🔗 Navigation Property
        public virtual trxBUSFTTHIKRGenerate trxBUSFTTHIKRGenerate { get; set; }
    }
}
