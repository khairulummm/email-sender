using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataIntegration.Domain.Entities.TBIGSADB01.TBGSecureAccess
{
    [Table("mstCredentialKia")]
    public class mstCredentialKia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [StringLength(10)]
        public string? Environment { get; set; }

        [Required]
        [StringLength(100)]
        public string? Grant_type { get; set; }

        [Required]
        [StringLength(100)]
        public string? Client_id { get; set; }

        [Required]
        public string? Client_secret { get; set; }

        [Required]
        [StringLength(100)]
        public string? Scope { get; set; }

        [Required]
        [StringLength(20)]
        public string? CreatedBy { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [StringLength(20)]
        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
