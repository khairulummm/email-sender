using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys
{
    [Table("mstBUSTravelDutiesCityAgent")]
    public class mstBUSTravelDutiesCityAgent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public int mstBUSTravelDutiesCityID { get; set; }

        [Required]
        public int mstBUSTravelAgentID { get; set; }

        [Required]
        [MaxLength(50)]
        public string? CityID { get; set; }

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
