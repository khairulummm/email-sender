using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Application.DTOs.ETender.Auction.MaterialScrapped
{
    public class MaterialScrappedSubmitFinal
    {
        [Key]
        public int ID { set; get; }
        public int FinalID { set; get; }
        public decimal FinalPrice { set; get; }
        public DateTime FinalDate { set; get; }
        public bool IsSync { set; get; }
        public DateTime SyncDate { set; get; }
    }
}
