using System.ComponentModel.DataAnnotations;

namespace TBIG_e_Tender.Domain.Entities.TBIGSYSDB01.TBIGETender
{
    public class TenderAanwijzingConfirmation
    {
        [Key]
        public long ID { get; set; }
        public string ProjectName { get; set; }
        public string LocationType { get; set; }
        public string Location { get; set; }
        public string? VendorID { get; set; }
        public string VendorName { get; set; }
        public string VendorEmail { get; set; }
        public string ScopeOfWork { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Token { get; set; }
        public bool? IsConfirm { get; set; }
        public bool? IsSync { get; set; }
        public string? Remarks { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
