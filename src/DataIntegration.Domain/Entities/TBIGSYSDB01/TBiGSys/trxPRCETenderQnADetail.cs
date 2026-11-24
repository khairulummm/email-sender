using System.ComponentModel.DataAnnotations;

namespace DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys
{
    public class trxPRCETenderQnADetail
    {
        [Key]
        public long ID { get; set; }
        public long trxPRCETenderQnAID { get; set; }
        public string? QuestionID { get; set; }
        public string? Question { get; set; }
        public string? Answer { get; set; }
        public string? PICAnswer { get; set; }
        public bool? IsSync { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}