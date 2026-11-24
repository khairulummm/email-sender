using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys
{
    [Table("mstBusTravelokaAirport")]
    public class mstBusTravelokaAirport
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [Required]
        [MaxLength(10)]
        public string? AirportCode { get; set; }

        [Required]
        [MaxLength(50)]
        public string? City { get; set; }

        [MaxLength(10)]
        public string? CountryID { get; set; }

        [Required]
        [MaxLength(10)]
        public string? CountryCode { get; set; }

        [Required]
        [MaxLength(10)]
        public string? AreaCode { get; set; }

        [Required]
        [MaxLength(50)]
        public string? TimeZone { get; set; }

        [Required]
        [MaxLength(200)]
        public string? InternationalAirportName { get; set; }

        [MaxLength(10)]
        public string? AirportIcaoCode { get; set; }

        [MaxLength(200)]
        public string? LocalAirportName { get; set; }

        [MaxLength(50)]
        public string? LocalCityName { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        [MaxLength(50)]
        public string? CreatedBy { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [MaxLength(50)]
        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }

}
