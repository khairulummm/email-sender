using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Domain.Entities.TBIGSYSDB01.TBGFTTH
{
    public class trxBUSFTTHIKRGenerate
    {
        [Key]
        public int ID { get; set; }

        public DateTime? DateGenerate { get; set; }

        public TimeSpan? StartTime { get; set; }

        public TimeSpan? FinishTime { get; set; }

        [Required]
        [MaxLength(20)]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [MaxLength(20)]
        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        // 🔗 Navigation Property — One-to-Many Relationship
        public virtual ICollection<trxBUSFTTHIKRGeneratePurchase> trxBUSFTTHIKRGeneratePurchase { get; set; } = new List<trxBUSFTTHIKRGeneratePurchase>();

    }
}
