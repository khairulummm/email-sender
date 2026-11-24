using System.ComponentModel.DataAnnotations;

namespace TBIG_e_Tender.Domain.Entities.TBIGSYSDB01.TBIGETender
{
    public class TenderQnADetail
    {
        [Key]
        public long ID { get; set; }
        public long TenderQnAID { get; set; }
        public string? QuestionID { get; set; }
        public string? Question { get; set; }
        public string? Answer { get; set; }
        public bool? IsSync { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
