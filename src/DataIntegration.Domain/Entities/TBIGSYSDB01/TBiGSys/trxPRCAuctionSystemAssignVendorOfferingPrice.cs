using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys
{
    public class trxPRCAuctionSystemAssignVendorOfferingPrice
    {
        [Key]       
        public long ID { get; set; }

        public long trxPRCAuctionSystemAssignVendorID { get; set; }

        public decimal? OfferPrice { get; set; }

        public string? SubmitBy { get; set; }

        public DateTime? SubmitDate { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime CreatedDate { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }

}
