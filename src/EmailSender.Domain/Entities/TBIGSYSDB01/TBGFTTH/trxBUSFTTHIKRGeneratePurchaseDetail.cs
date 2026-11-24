using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Domain.Entities.TBIGSYSDB01.TBGFTTH
{
    [Table("trxBUSFTTHIKRGeneratePurchaseDetail")]
    public class trxBUSFTTHIKRGeneratePurchaseDetail
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [ForeignKey(nameof(trxBUSFTTHIKRGeneratePurchase))]
        public int trxBUSFTTHIKRGeneratePurchaseID { get; set; }

        [StringLength(50)]
        public string? ItemID { get; set; }

        [Required]
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Qty { get; set; }

        [Required]
        [StringLength(50)]
        public string UoM { get; set; }

        [Required]
        [Column(TypeName = "decimal(9, 2)")]
        public decimal Price { get; set; }

        [Required]
        [StringLength(20)]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [StringLength(20)]
        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        // 🔗 Navigation Property (Many-to-One)
        public virtual trxBUSFTTHIKRGeneratePurchase trxBUSFTTHIKRGeneratePurchase { get; set; }

    }
}
