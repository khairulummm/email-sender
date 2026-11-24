using System.ComponentModel.DataAnnotations;

namespace DataIntegration.Domain.Entities.TBIGSYSDB01.TBGFTTH
{
    public class vwBUSIKRDataPurchase
    {
        [Key]
        public Int64 RowNumber { get; set; }
        public int GenerateID { get; set; }
        public string CompanyID { get; set; }
        public string VendorID { get; set; }
        public int ResidenceID { get; set; }
        public string CustomerID { get; set; }
        public int WOTypeID { get; set; }
        public double? Loop { get; set; }
    }
}
