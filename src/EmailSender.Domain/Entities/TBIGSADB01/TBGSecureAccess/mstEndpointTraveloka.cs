using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataIntegration.Domain.Entities.TBIGSADB01.TBGSecureAccess
{
    [Table("mstEndpointTraveloka")]
    public class mstEndpointTraveloka
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [ForeignKey(nameof(RootTraveloka))]
        public int? RootTravelokaID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Code { get; set; } = null!;

        [Required]
        [MaxLength(255)]
        public string Endpoint { get; set; } = null!;

        [Required]
        [MaxLength(10)]
        public string Environment { get; set; } = null!;

        [MaxLength(200)]
        public string? Description { get; set; }

        [MaxLength(50)]
        public string? StgTableName { get; set; }

        [Required]
        [MaxLength(20)]
        public string CreatedBy { get; set; } = null!;

        [Required]
        public DateTime CreatedDate { get; set; }

        [MaxLength(20)]
        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public virtual mstRootTraveloka? RootTraveloka { get; set; }
    }
}
