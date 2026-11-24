using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Application.DTOs.ETender.Auction.MaterialScrapped
{
    public class MaterialScrappedSubmitTransfer
    {
        [Key]
        public int ID { set; get; }
        public int TransferID { set; get; }
        public int TransactionTypeID { set; get; }
        public string TransactionCategory { set; get; }
        public string CompanyIDAX { set; get; }
        public string AccountNumberBank { set; get; }
        public decimal Amount { set; get; }
        public DateTime? TransferDate { set; get; }
        public string AdditionalInformation { set; get; }
        public string AccountName { set; get; }
        public string AccountNumber { set; get; }
        public bool IsSync { set; get; }
        public DateTime? SyncDate { set; get; }
        public DateTime CreatedDate { set; get; }
    }
}
