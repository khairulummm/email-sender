using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Application.DTOs.ETender.Auction.MaterialScrapped
{
    public class MaterialScrappedSubmitOffer
    {
        [Key]
        public int ID { set; get; }
        public int OfferID { set; get; }
        public decimal OfferPrice { set; get; }
        public DateTime OfferDate { set; get; }
        public bool IsSync { set; get; }
        public DateTime SyncDate { set; get; }
        public DateTime? CreatedDate { set; get; }
    }
}
