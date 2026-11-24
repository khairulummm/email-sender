using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys
{
    [Table("mstBUSKiaAirline")]
    public class mstBUSKiaAirline
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        public int AirlineID { get; set; }

        [Required]
        [MaxLength(100)]
        public string? AirlineName { get; set; }

        public bool IsGDS { get; set; }

        public bool IsActive { get; set; }

        [Required]
        [MaxLength(20)]
        public string? CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        [MaxLength(20)]
        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
