using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys
{
    [Table("trxAPIKiaHistory")]
    public class trxAPIKiaHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        public string? Token { get; set; }

        public DateTime SentDate { get; set; }

        [Required]
        public string? Url { get; set; }

        public string? Request { get; set; }
        public string? Response { get; set; }

        public int StatusID { get; set; }

        public int? APIStatusCode { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        public string? CreatedBy { get; set; }
    }
}
