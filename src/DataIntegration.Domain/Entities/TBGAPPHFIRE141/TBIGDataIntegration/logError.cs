using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Domain.Entities.TBGAPPHFIRE141.TBIGDataIntegration
{
    [Table("logError", Schema = "dbo")]
    public class logError
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        public string SchedullerID { get; set; }

        [MaxLength(500)]
        public string? Project { get; set; }

        public string? Message { get; set; }

        public string? InnerException { get; set; }

        public string? StackTrace { get; set; }

        public string? Service { get; set; }

        public string? Method { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(20)]
        public string CreatedBy { get; set; } = null!;

        public DateTime? UpdatedDate { get; set; }

        [MaxLength(20)]
        public string? UpdatedBy { get; set; }
    }
}
