using System.ComponentModel.DataAnnotations;

namespace DataIntegration.Domain.Entities.TBIGSYSDB01.TBGFTTH
{
    public class vwBUSIKRGeneratePurchase_ReleasePlan
    {
        [Key]
        public int ID { get; set; }
        public string HomepassNumber { get; set; }
        public string CustomerID { get; set; }
        public string WOID { get; set; }
        public string CustomerWOID { get; set; }
        public string Sonumb { get; set; }
        public int? SiteID { get; set; }
        public int? Sitename { get; set; }
        public string VendorID { get; set; }
        public string VendorName { get; set; }
        public string CompanyID { get; set; }
        public string ResidenceName { get; set; }
        public string PurchaseOrderName { get; set; }
        public string WOType { get; set; }
        public string ContractNumber { get; set; }
        public DateTime? InstallationDate { get; set; }
        public string InstallationStatus { get; set; }
        public string PurchaseRequestCreator { get; set; }
        public string PurchaseRequestDiketahui { get; set; }
        public string PurchaseRequestDisetujui { get; set; }
        public string PurchaseRequestDikonfirmasi { get; set; }
        public string PurchaseOrderCreator { get; set; }
        public int? StatusID { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? WOTypeID { get; set; }
        public string TermPayment { get; set; }
        public string ResidenceID { get; set; }
        public string RegionID { get; set; }
        public string? WOStatusID { get; set; }
    }
}
