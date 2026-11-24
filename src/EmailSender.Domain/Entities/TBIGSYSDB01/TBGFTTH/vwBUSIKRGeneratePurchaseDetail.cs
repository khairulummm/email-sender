using System.ComponentModel.DataAnnotations;

namespace DataIntegration.Domain.Entities.TBIGSYSDB01.TBGFTTH
{
    public class vwBUSIKRGeneratePurchaseDetail
    {
        [Key]
        public int trxBUSFTTHIKRGeneratePurchaseID { get; set; }
        public string? ItemID { get; set; }
        public int Qty { get; set; }
        public string UoM { get; set; }
        public decimal? Price { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
