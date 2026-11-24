using System.ComponentModel.DataAnnotations;

namespace DataIntegration.Domain.Entities.TBIGSYSDB01.TBGFTTH
{
    public class vwBUSIKRGeneratePurchaseDetailSummary
    {
        [Key]
        public int GeneratePurchaseDetailID { get; set; }
        public int GeneratePurchaseID { get; set; }
        public int WOTypeID { get; set; }
        public string HomePassNumber { get; set; }
        public string ItemName { get; set; }
        public decimal Quantity { get; set; }
        public string UoM { get; set; }
        public decimal? Price { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
