using System.ComponentModel.DataAnnotations;

namespace DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys
{
    public class trxPRCAuctionSystemTBGFinalOfferingPrice
    {
        [Key]
        public long ID { get; set; }
        public long trxPRCAuctionSystemHeaderID { get; set; }
        public decimal? FinalOfferPrice { get; set; }
        public DateTime? MaxFinalOfferDate { get; set; }
        public DateTime? SubmitDate { get; set; }
        public string? SubmitBy { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

}
