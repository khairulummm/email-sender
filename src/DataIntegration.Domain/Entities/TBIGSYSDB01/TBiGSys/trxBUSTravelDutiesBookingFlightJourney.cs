using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys
{
    [Table("trxBUSTravelDutiesBookingFlightJourney")]
    public class trxBUSTravelDutiesBookingFlightJourney
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int trxBUSTravelDutiesBookingFlightID { get; set; }

        public int Sequence { get; set; }

        [Required]
        [MaxLength(10)]
        public string? AirportOrigin { get; set; }

        [Required]
        [MaxLength(10)]
        public string? AirportDestination { get; set; }

        [Required]
        [MaxLength(10)]
        public string? AirlineCode { get; set; }

        [Required]
        [MaxLength(50)]
        public string? AirlineName { get; set; }

        [Required]
        [MaxLength(20)]
        public string? FlightCode { get; set; }

        public DateTime FlightDate { get; set; }

        public DateTime LandingDate { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        [MaxLength(20)]
        public string? CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        [MaxLength(20)]
        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }

}
