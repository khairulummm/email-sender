using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys
{
    [Table("trxPRCSPHNonShoppingListNonNetworkNegotiation")]
    public class trxPRCSPHNonShoppingListNonNetworkNegotiation
    {
        [Key]
        public long ID { get; set; }

        [Required]
        public long trxPRCSPHNonShoppingListNonNetworkAssignVendorID { get; set; }

        [Required]
        public long trxPRCSPHNonShoppingListNonNetworkWorkTypeID { get; set; }

        [Required]
        public int mstPRCSPHNonShoppingListNonNetworkNegoStatusID { get; set; }
        
        public int? mstPRCSPHNonShoppingListNonNetworkPICTypeID { get; set; }

        [MaxLength(50)]
        public string? RequestorSubmitPriceBy { get; set; }

        public DateTime? RequestorSubmitPriceDate { get; set; }

        [Required]
        public decimal RequestPricePerUnit { get; set; }

        [MaxLength(50)]
        public string? TBGSubmitPriceBy { get; set; }

        public DateTime? TBGSubmitPriceDate { get; set; }

        public decimal? TBGPrice { get; set; }

        public DateTime? VendorSubmitPriceDate { get; set; }

        public decimal? VendorPrice { get; set; }

        [Required]
        [MaxLength(200)]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [MaxLength(200)]
        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
