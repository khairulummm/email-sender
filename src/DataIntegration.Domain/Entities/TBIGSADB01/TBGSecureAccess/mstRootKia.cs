using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataIntegration.Domain.Entities.TBIGSADB01.TBGSecureAccess
{
    [Table("mstRootKia")]
    public class mstRootKia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [StringLength(10)]
        public string? Environment { get; set; }

        [Required]
        [StringLength(50)]
        public string? Code { get; set; }

        [Required]
        [StringLength(255)]
        public string? Root { get; set; }

        [Required]
        [StringLength(20)]
        public string? CreatedBy { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [StringLength(20)]
        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        //public virtual ICollection<mstEndpointKia>? Endpoints { get; set; }
    }
}
