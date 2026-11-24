using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Domain.Entities.TBIGSYSDB01.TBGFTTH
{
    public class uspBUSIKRGeneratePurchase
    {
        [Key]
        public int ReleasePlanID { get; set; }
        public int trxBUSFTTHIKRGenerateID { get; set; }
        public string HomepassNumber { get; set; }
        public string CustomerID { get; set; }
        public string WOID { get; set; }
        public string CustomerWOID { get; set; }
        public string Sonumb { get; set; }
        public string SiteID { get; set; }
        public string Sitename { get; set; }
        public string VendorID { get; set; }
        public string CompanyID { get; set; }
        public string ResidenceID { get; set; }
        public string PurchaseRequestNumber { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string PurchaseOrderName { get; set; }
        public int WOTypeID { get; set; }
        public string TermPayment { get; set; }
        public string ContractNumber { get; set; }
        public string PurchaseRequestCreator { get; set; }
        public string PurchaseRequestDiketahui { get; set; }
        public string PurchaseRequestDisetujui { get; set; }
        public string PurchaseRequestDikonfirmasi { get; set; }
        public string PurchaseOrderCreator { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
