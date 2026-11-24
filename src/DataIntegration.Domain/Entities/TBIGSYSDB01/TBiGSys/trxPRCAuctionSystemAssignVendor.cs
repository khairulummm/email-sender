using System.ComponentModel.DataAnnotations;

namespace DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys
{
    public class trxPRCAuctionSystemAssignVendor
    {
        [Key]
        public long ID { get; set; }
        public long trxPRCAuctionSystemHeaderID { get; set; }
        public int mstPRCAuctionSystemVendorTypeID { get; set; }
        public int? mstPRCAuctionSystemVendorListingID { get; set; }
        public int? mstPRCAuctionSystemVendorNonListingID { get; set; }
        public int? mstPRCAuctionSystemStatusSubmitPriceID { get; set; }
        public int? mstPRCAuctionSystemVendorRecommendationTypeID { get; set; }
        public bool IsDelete { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

}
