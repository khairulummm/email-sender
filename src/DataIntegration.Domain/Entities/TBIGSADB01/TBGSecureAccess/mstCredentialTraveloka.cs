using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataIntegration.Domain.Entities.TBIGSADB01.TBGSecureAccess
{
    [Table("mstCredentialTraveloka")]
    public class mstCredentialTraveloka
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(255)]
        public string Root { get; set; } = null!;

        [MaxLength(10)]
        public string? Environment { get; set; }

        [MaxLength(200)]
        public string? Description { get; set; }

        [Required]
        [MaxLength(255)]
        public string Username { get; set; } = null!;

        [Required]
        [MaxLength(255)]
        public string Password { get; set; } = null!;

        [MaxLength(100)]
        public string? CredentialName { get; set; }

        public string? ClientID { get; set; } 

        public string? ClientSecret { get; set; } 

        [MaxLength(255)]
        public string? TokenType { get; set; }

        public string? CurrentToken { get; set; } 

        public DateTime? TokenExpired { get; set; }

        [Required]
        [MaxLength(20)]
        public string CreatedBy { get; set; } = null!;

        [Required]
        public DateTime CreatedDate { get; set; }

        [MaxLength(20)]
        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
