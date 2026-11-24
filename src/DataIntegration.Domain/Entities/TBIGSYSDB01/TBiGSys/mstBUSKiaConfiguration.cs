using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys
{
    [Table("mstBUSKiaConfiguration")]
    public class mstBUSKiaConfiguration
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string? ConfigKey { get; set; }

        [MaxLength(150)]
        public string? ConfigValue { get; set; }

        [MaxLength(500)]
        public string? ValueOption { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        [Required]
        [MaxLength(20)]
        public string? CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
