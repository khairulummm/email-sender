using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataIntegration.Domain.Entities.TBIGSADB01.TBGSecureAccess
{
    [Table("mstEndpointKia")]
    public class mstEndpointKia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        //[ForeignKey(nameof(RootKia))]
        [Required]
        public int RootKiaID { get; set; }

        [Required]
        [StringLength(10)]
        public string? Environment { get; set; }

        [Required]
        [StringLength(50)]
        public string? Code { get; set; }

        [Required]
        [StringLength(10)]
        public string? Method { get; set; }

        [Required]
        [StringLength(255)]
        public string? Endpoint { get; set; }

        [StringLength(200)]
        public string? Description { get; set; }

        [Required]
        [StringLength(20)]
        public string? CreatedBy { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [StringLength(20)]
        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        //[ForeignKey("RootKiaID")]
        //public mstRootKia? RootKia { get; set; }
    }
}
