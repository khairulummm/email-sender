using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys
{
    [Table("mstBUSKiaAirport")]
    public class mstBUSKiaAirport
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(10)]
        public string? Code { get; set; }

        [Required]
        [MaxLength(50)]
        public string? CityName { get; set; }

        [Required]
        [MaxLength(10)]
        public string? CountryCode { get; set; }

        [Required]
        [MaxLength(200)]
        public string? AirportName { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal Locale { get; set; }

        public bool? IsNonGds { get; set; }
        public bool? IsGds { get; set; }
        public bool? ForOverride { get; set; }

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
