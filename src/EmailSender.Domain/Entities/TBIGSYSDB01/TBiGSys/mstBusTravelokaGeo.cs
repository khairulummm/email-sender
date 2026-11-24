using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys
{
    [Table("mstBusTravelokaGeo")]
    public class mstBusTravelokaGeo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string? GeoID { get; set; }

        [Required]
        [MaxLength(100)]
        public string? ParentID { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Type { get; set; }

        [Required]
        [MaxLength(250)]
        public string? Name { get; set; }

        [MaxLength(250)]
        public string? LocaleName { get; set; }

        public decimal? Longitude { get; set; }

        public decimal? Latitude { get; set; }

        [Required]
        public bool Valid { get; set; }

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
