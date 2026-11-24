using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Application.DTOs.ETender.Auction.FIT
{
    public class FITActualSchedule
    {
        [Key]
        public int ID { get; set; }
        public int RequestID { get; set; }
        public string Token { get; set; }
        public DateTime? ActualDate { get; set; }
        public DateTime? ActualSubmittedDate { get; set; }
        public bool IsSync { get; set; }
        public DateTime SyncDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
