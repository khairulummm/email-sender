using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys
{
    public class logPRCAuctionSystemAssignVendorTransferPrice
    {
        [Key]
        public long ID { get; set; }
        public long trxPRCAuctionSystemAssignVendorTransferPriceID { get; set; }
        public long trxPRCAuctionSystemAssignVendorID { get; set; }
        public int? mstFINRefundTransactionTypeID { get; set; }
        public string? mstFINRefundTransactionCategory { get; set; }
        public string? mstCompanyIDAX { get; set; }
        public string? AccountNumber { get; set; }
        public decimal? TransferPrice { get; set; }
        public DateTime? TransferDate { get; set; }
        public string? AdditionalInformation { get; set; }
        public string? SenderName { get; set; }
        public string? VendorAccount { get; set; }
        public DateTime? SubmitDate { get; set; }
        public string? SubmitBy { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
