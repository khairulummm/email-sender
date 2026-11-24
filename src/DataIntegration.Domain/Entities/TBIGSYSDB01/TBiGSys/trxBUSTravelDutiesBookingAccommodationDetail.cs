using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys
{
    [Table("trxBUSTravelDutiesBookingAccommodationDetail")]
    public class trxBUSTravelDutiesBookingAccommodationDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public int trxBUSTravelDutiesBookingAccommodationID { get; set; }

        [Required]
        public long trxBUSHCTravelDutiesRegistrationID { get; set; }

        [Required]
        public long trxBUSHCTravelDutiesLocationID { get; set; }

        [Required]
        [MaxLength(50)]
        public string? DestinationType { get; set; }

        [Required]
        public bool IsMain { get; set; }

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
