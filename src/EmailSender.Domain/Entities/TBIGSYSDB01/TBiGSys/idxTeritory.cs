using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys
{
    [Table("idxTeritory")]
    public class idxTeritory
    {
        [Key]
        [Column("idxTeritoryID")]
        public int IdxTeritoryID { get; set; }

        [Required]
        public int ResidenceID { get; set; }

        [Required]
        public int ProvinceID { get; set; }

        [Required]
        public int RegionID { get; set; }
    }
}
