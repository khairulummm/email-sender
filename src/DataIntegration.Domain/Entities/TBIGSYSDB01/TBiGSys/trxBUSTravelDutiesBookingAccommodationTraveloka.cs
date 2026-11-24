using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys
{
    [Table("trxBUSTravelDutiesBookingAccommodationTraveloka")]
    public class trxBUSTravelDutiesBookingAccommodationTraveloka
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public int trxBUSTravelDutiesBookingAccommodationID { get; set; }

        [Required]
        [MaxLength(50)]
        public string? ConfirmationID { get; set; }

        public int? Revision { get; set; }

        public string? BookingID { get; set; }

        public string? ItineraryID { get; set; }

        public string? RateKey { get; set; }

        [MaxLength(50)]
        public string? BookingStatus { get; set; }

        public int? Iteration { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        [Required]
        [MaxLength(20)]
        public string? CreatedBy { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [MaxLength(20)]
        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
