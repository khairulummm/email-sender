using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys
{
    public class stgVendorRegistrationData
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string JsonString { get; set; }

        [Required]
        public bool IsProcessed { get; set; } = false;

        [Required]
        [StringLength(50)]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [StringLength(50)]
        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;
    }
}
