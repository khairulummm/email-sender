using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys
{
    [Table("mstBusTravelokaError")]
    public class mstBusTravelokaError
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(20)]
        public string? Source { get; set; }

        [Required]
        [MaxLength(50)]
        public string? ErrorCode { get; set; }

        [Required]
        [MaxLength(500)]
        public string? ErrorMessage { get; set; }

        [MaxLength(500)]
        public string? DisplayError { get; set; }

        [Required]
        [MaxLength(20)]
        public string? CreatedBy { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [MaxLength(20)]
        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }

}
