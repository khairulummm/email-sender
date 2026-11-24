using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataIntegration.Domain.Entities.TBIGSADB01.TBGSecureAccess
{
    [Table("mstRootTraveloka")]
    public class mstRootTraveloka
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Code { get; set; } = null!;

        [Required]
        [MaxLength(255)]
        public string Root { get; set; } = null!;

        [Required]
        [MaxLength(10)]
        public string Environment { get; set; } = null!;

        [Required]
        [MaxLength(20)]
        public string CreatedBy { get; set; } = null!;

        [Required]
        public DateTime CreatedDate { get; set; }

        [MaxLength(20)]
        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<mstEndpointTraveloka>? Endpoints { get; set; }
    }
}
