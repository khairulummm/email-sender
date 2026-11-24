using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys
{
    [Table("mstBusTravelokaConfiguration")]
    public class mstBusTravelokaConfiguration
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

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
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        public string? CreatedBy { get; set; }
    }
}
