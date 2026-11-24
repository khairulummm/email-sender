using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys
{
    [Table("mstBusTravelokaProperty")]
    public class mstBusTravelokaProperty
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string? PropertyId { get; set; }

        [Required]
        [MaxLength(500)]
        public string? PropertyName { get; set; }

        [MaxLength(255)]
        public string? Address { get; set; }

        public int? Star { get; set; }

        [MaxLength(255)]
        public string? Image { get; set; }

        [Required]
        public bool IsActive { get; set; }

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
