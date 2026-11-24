using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Domain.Entities.TBIGSADB01.TBGSecureAccess
{
    [Table("vwRootEndpointKia")]
    public class vwRootEndpointKia
    {
        [Required]
        [MaxLength(10)]
        public string Environment { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string EndpointCode { get; set; } = null!;

        [Required]
        [MaxLength(10)]
        public string Method { get; set; } = null!;

        [Required]
        [MaxLength(255)]
        public string Root { get; set; } = null!;

        [Required]
        [MaxLength(255)]
        public string Endpoint { get; set; } = null!;

        [Key]
        [Required]
        [MaxLength(510)]
        public string URL { get; set; } = null!;

        [Required]
        [MaxLength(200)]
        public string Description { get; set; } = null!;
    }
}
