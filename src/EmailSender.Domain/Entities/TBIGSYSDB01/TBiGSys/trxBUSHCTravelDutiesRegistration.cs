using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys
{

    [Table("trxBUSHCTravelDutiesRegistration")]
    public class trxBUSHCTravelDutiesRegistration
    {
        [Key]
        public long ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string? RequestNo { get; set; }

        [MaxLength(50)]
        public string? STDNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string? ApplicantID { get; set; }

        [Required]
        public short mstBUSHCTravelDutiesTypeID { get; set; }

        public short? mstFINAdvExpCostGroupID { get; set; }

        [Required]
        [MaxLength(5)]
        public string? mstCompanyID { get; set; }

        [MaxLength(255)]
        public string? TravelApprovalNote { get; set; }

        [Required]
        [MaxLength(50)]
        public string? PaymentType { get; set; }

        public int? BankGroupsID { get; set; }

        [MaxLength(20)]
        public string? AccountNumber { get; set; }

        [MaxLength(255)]
        public string? AccountName { get; set; }

        [Required]
        public short mstBUSHCTravelDutiesOfficialDutiesID { get; set; }

        [MaxLength(255)]
        public string? OfficialDutiesPurposes { get; set; }

        [Required]
        public int mstBUSTravelDutiesCountriesID { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required]
        [MaxLength(50)]
        public string? DestinationType { get; set; }

        [MaxLength(50)]
        public string? AdditionalAirplane { get; set; }

        [MaxLength(50)]
        public string? AdditionalHotel { get; set; }

        [Required]
        public bool NeedTaxi { get; set; }

        [Required]
        public bool IsTBG { get; set; }

        [Required]
        public bool IsSubmit { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        public bool? IsApprovalDone { get; set; }

        [Column(TypeName = "decimal(19][0)")]
        public decimal? ProcessOID { get; set; }

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
