using System.ComponentModel.DataAnnotations;

namespace DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys
{
    public class vwPRCSPHNonShoppingListNonNetworkNegotiationCount
    {
        [Key]
        public long NegotiationID { get; set; }
        public long HeaderID { get; set; }
        public int? HeaderStatusID { get; set; }
        public string? HeaderStatus { get; set; }
        public int CountNego { get; set; }
    }
}
