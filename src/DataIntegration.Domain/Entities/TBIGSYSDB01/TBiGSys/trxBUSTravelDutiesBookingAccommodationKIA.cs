using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys
{
    [Table("trxBUSTravelDutiesBookingAccommodationKIA")]
    public class trxBUSTravelDutiesBookingAccommodationKIA
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public int trxBUSTravelDutiesBookingAccommodationID { get; set; }

        [Required]
        public string? CorrelationID { get; set; }

        [Required]
        public string? ConfirmationID { get; set; }

        public string? PnrID { get; set; }

        [MaxLength(50)]
        public string? BookingStatus { get; set; }

        [MaxLength(50)]
        public string? BookingID { get; set; }

        [MaxLength(50)]
        public string? BookingCode { get; set; }

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
