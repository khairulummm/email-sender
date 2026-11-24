using System.ComponentModel.DataAnnotations;

namespace DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys
{
    public class trxBUSFITRequestToken
    {
        [Key]
        public int ID { get; set; }
        public int trxBUSFITRequestID { get; set; }
        public string Token { get; set; }
        public bool IsUsed { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? MaxDate { get; set; }
    }
}