using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys
{
    [Table("trxAPITravelokaHistory")]
    public class trxAPITravelokaHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        public string? Token { get; set; }

        [Required]
        public DateTime SentDate { get; set; }

        [Required]
        public string? Endpoint { get; set; }

        public string? Request { get; set; }

        public string? Response { get; set; }

        [Required]
        public int StatusID { get; set; }

        public int? APIStatusCode { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        public string? CreatedBy { get; set; }
    }

}
