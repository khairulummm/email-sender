using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys
{
    [Table("trxBUSTravelDutiesBookingFlight")]
    public class trxBUSTravelDutiesBookingFlight
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int trxBUSHCTravelDutiesRegistrationID { get; set; }

        public int trxBUSHCTravelDutiesLocationID { get; set; }

        public int mstBUSTravelAgentID { get; set; }

        [Required]
        [MaxLength(50)]
        public string? DestinationType { get; set; }

        [Column(TypeName = "date")]
        public DateTime FlightDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime LandingDate { get; set; }

        [Required]
        [MaxLength(10)]
        public string? AirportOrigin { get; set; }

        [Required]
        [MaxLength(10)]
        public string? AirportDestination { get; set; }

        public int NumberOfTransit { get; set; }

        [Column(TypeName = "numeric(23,3)")]
        public decimal Total { get; set; }

        public bool? IsRefundable { get; set; }

        public bool IsReturn { get; set; }

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
