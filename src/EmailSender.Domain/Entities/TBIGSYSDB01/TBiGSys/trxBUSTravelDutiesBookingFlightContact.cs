using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys
{
    [Table("trxBUSTravelDutiesBookingFlightContact")]
    public class trxBUSTravelDutiesBookingFlightContact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int trxBUSTravelDutiesBookingFlightID { get; set; }

        [Required]
        [MaxLength(200)]
        public string? ContactFirstName { get; set; }

        [MaxLength(200)]
        public string? ContactLastName { get; set; }

        [Required]
        [MaxLength(20)]
        public string? ContactMobileNumber { get; set; }

        [MaxLength(20)]
        public string? ContactOtherPhone { get; set; }

        [Required]
        [MaxLength(100)]
        public string? ContactEmail { get; set; }

        [MaxLength(100)]
        public string? ContactOtherEmail { get; set; }

        [Required]
        [MaxLength(5)]
        public string? TravelerTitle { get; set; }

        [Required]
        [MaxLength(200)]
        public string? TravelerFirstName { get; set; }

        [MaxLength(200)]
        public string? TravelerLastName { get; set; }

        public DateTime? TravelerBirthdate { get; set; }

        [MaxLength(10)]
        public string? TravelerNationality { get; set; }

        [Required]
        [MaxLength(50)]
        public string? TravelerDocumentType { get; set; }

        [Required]
        [MaxLength(50)]
        public string? TravelerDocumentNumber { get; set; }

        [MaxLength(200)]
        public string? EmergencyFullName { get; set; }

        [MaxLength(20)]
        public string? EmergencyPhone { get; set; }

        [MaxLength(100)]
        public string? EmergencyEmail { get; set; }

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
