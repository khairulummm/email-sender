using System.ComponentModel.DataAnnotations;

namespace DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys
{
    public class trxPRCETenderActivity
    {
        [Key]
        public long ID { get; set; }
        public long trxPRCETenderHeaderID { get; set; }
        public int mstPRCETenderActivityID { get; set; }
        public int? Sort { get; set; }
        public DateTime? StartActivity { get; set; }
        public DateTime? FinishActivity { get; set; }
        public string PIC { get; set; }
        public string Remark { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}