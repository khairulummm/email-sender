using System.ComponentModel.DataAnnotations;

namespace DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys
{
    public class trxPRCSPHNonShoppingListNonNetworkAssignVendorToken
    {
        [Key]
        public long ID { get; set; }

        [Required]
        public long trxPRCSPHNonShoppingListNonNetworkAssignVendorID { get; set; }

        [Required]
        public string Token { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
