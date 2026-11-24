using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys
{
    [Table("trxBUSTravelDutiesBookingAccommodation")]
    public class trxBUSTravelDutiesBookingAccommodation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public int mstBUSTravelAgentID { get; set; }

        [Required]
        [MaxLength(100)]
        public string? AccommodationID { get; set; }

        [Required]
        [MaxLength(200)]
        public string? AccommodationName { get; set; }

        [MaxLength(50)]
        public string? AccommodationPhone { get; set; }

        public string? AccommodationImage { get; set; }

        [MaxLength(500)]
        public string? AccommodationLocation { get; set; }

        [MaxLength(100)]
        public string? RoomID { get; set; }

        [Required]
        [MaxLength(200)]
        public string? RoomName { get; set; }

        [Required]
        public int Star { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime CheckIn { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime CheckOut { get; set; }

        [Required]
        public int NumOfAdult { get; set; }

        [Required]
        [Column(TypeName = "numeric(23,3)")]
        public decimal Total { get; set; }

        public bool? Availability { get; set; }

        [Required]
        public bool IsBreakfast { get; set; }

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
