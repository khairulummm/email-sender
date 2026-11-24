using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys
{
    [Table("trxBUSTravelDutiesBookingFlightTraveloka")]
    public class trxBUSTravelDutiesBookingFlightTraveloka
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int trxBUSTravelDutiesBookingFlightID { get; set; }

        [Required]
        public string? FlightID { get; set; }

        public string? BookingID { get; set; }

        [MaxLength(20)]
        public string? PnrCode { get; set; }

        public bool? PaymentConfirmation { get; set; }

        [MaxLength(50)]
        public string? PaymentStatus { get; set; }

        [MaxLength(50)]
        public string? TicketStatus { get; set; }

        public int? Iteration { get; set; }

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
