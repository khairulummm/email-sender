using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Domain.Entities.TBGAPPHFIRE141.TBIGDataIntegration
{
    [Table("logJobRequest", Schema = "dbo")]
    public class logJobRequest
    {
        [Key]
        public long ID { get; set; }

        public string SchedullerID { get; set; }

        public string Job { get; set; }

        public string Method { get; set; }

        public string Request { get; set; }

        public string? Response { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ExecutionTime { get; set; }

        [Required]
        [MaxLength(200)]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [MaxLength(200)]
        public string UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
