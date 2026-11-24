using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataIntegration.Domain.Entities.HTBGDBS03.TBG_Sys
{
    [Table("TR_PurchReq_Line", Schema = "tbg")]
    public class TR_PurchReq_Line
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [MaxLength(30)]
        public string? RequestId { get; set; }

        [MaxLength(30)]
        public string? PurchReqId { get; set; }

        public int? LineNumber { get; set; }

        [MaxLength(20)]
        public string? ItemId { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string? Name { get; set; }

        [Column(TypeName = "numeric(28,2)")]
        public decimal? PurchQty { get; set; }

        [MaxLength(30)]
        public string? PurchUnit { get; set; }

        [Column(TypeName = "numeric(28,2)")]
        public decimal? PurchPrice { get; set; }

        [MaxLength(3)]
        public string? CurrencyCode { get; set; }

        [MaxLength(20)]
        public string? VendorAccount { get; set; }

        [MaxLength(30)]
        public string? PurchFQCaseId { get; set; }

        public DateTime? RequiredDate { get; set; }

        [Column(TypeName = "numeric(28,2)")]
        public decimal? LineAmount { get; set; }

        [MaxLength(30)]
        public string? Dimension { get; set; }

        [Column("Dimension2_")]
        [MaxLength(30)]
        public string? Dimension2 { get; set; }

        [Column("Dimension3_")]
        [MaxLength(30)]
        public string? Dimension3 { get; set; }

        [MaxLength(30)]
        public string? PurchId { get; set; }

        [MaxLength(20)]
        public string? ProjId { get; set; }

        [MaxLength(50)]
        public string? AuditUser { get; set; }

        public DateTime? AuditDate { get; set; }

        [MaxLength(50)]
        public string? ItemIDDetail { get; set; }

        [Column(TypeName = "numeric(18,2)")]
        public decimal? PercentageUtilized { get; set; }
    }
}
