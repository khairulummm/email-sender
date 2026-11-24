using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys
{
    [Table("trxBUSHCTravelDutiesLocationsSite")]
    public class trxBUSHCTravelDutiesLocationsSite
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public long trxBUSHCTravelDutiesRegistrationID { get; set; }

        [Required]
        public int mstProvinceID { get; set; }

        [Required]
        public int mstResidenceID { get; set; }

        [Required]
        [MaxLength(30)]
        public string? SONumb { get; set; }

        [Required]
        public DateTime DepartureDate { get; set; }

        [Required]
        public DateTime ReturnDate { get; set; }

        [Required]
        public short mstBUSHCTransportationID { get; set; }

        [Required]
        public short mstBUSHCAccomodationID { get; set; }

        [MaxLength(50)]
        public string? DepartureFrom { get; set; }

        [Required]
        [MaxLength(255)]
        public string? Note { get; set; }

        public int? AirportOriginID { get; set; }

        public int? AirportDestinationID { get; set; }

        public int? StationOriginID { get; set; }

        public int? StationDestinationID { get; set; }

        [Required]
        public int IndexTable { get; set; }

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
