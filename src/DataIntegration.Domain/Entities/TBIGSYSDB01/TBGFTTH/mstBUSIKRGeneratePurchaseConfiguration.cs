using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataIntegration.Domain.Entities.TBIGSYSDB01.TBGFTTH
{
    [Table("mstBUSIKRGeneratePurchaseConfiguration")]
    public class mstBUSIKRGeneratePurchaseConfiguration
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
        [MaxLength(100)]
        public string? CreatedBy { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }
    }
}
