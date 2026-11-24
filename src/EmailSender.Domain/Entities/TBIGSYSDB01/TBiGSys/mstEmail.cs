using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys
{
    [Table("mstEmail")]
    public class mstEmail
    {
        [Key]
        public int MstEmailID { get; set; }

        [Required]
        [MaxLength(100)]
        public string? EmailName { get; set; }

        [Required]
        [MaxLength(250)]
        public string? Subject { get; set; }

        [Required]
        public string? Body { get; set; }

        [Required]
        public string? Query { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        [MaxLength(200)]
        public string? Description { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(20)]
        public string? CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [MaxLength(20)]
        public string? UpdatedBy { get; set; }
    }
}
