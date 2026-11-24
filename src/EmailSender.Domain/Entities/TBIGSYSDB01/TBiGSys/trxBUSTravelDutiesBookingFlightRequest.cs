using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys
{
    [Table("trxBUSTravelDutiesBookingFlightRequest")]
    public class trxBUSTravelDutiesBookingFlightRequest
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int trxBUSTravelDutiesBookingFlightID { get; set; }

        public string? ConfirmJson { get; set; }

        public string? IssuedJson { get; set; }

        [MaxLength(100)]
        public string? SchedullerID { get; set; }

        public bool? IsSuccess { get; set; }

        [MaxLength(100)]
        public string? Status { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

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
