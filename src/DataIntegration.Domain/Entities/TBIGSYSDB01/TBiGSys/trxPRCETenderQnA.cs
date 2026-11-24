using System.ComponentModel.DataAnnotations;

namespace DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys
{
    public class trxPRCETenderQnA
    {
        [Key]
        public long ID { get; set; }
        public long trxPRCETenderHeaderID { get; set; }
        public int mstPRCETenderVendorTypeID { get; set; }
        public string? VendorID { get; set; }
        public string VendorName { get; set; }
        public string VendorEmail { get; set; }
        public string Token { get; set; }
        public bool? IsSync { get; set; }
        public bool? IsCloseQnA { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}