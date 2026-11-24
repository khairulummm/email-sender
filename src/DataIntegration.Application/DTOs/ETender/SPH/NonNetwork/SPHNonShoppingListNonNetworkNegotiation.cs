using System.ComponentModel.DataAnnotations;

namespace DataIntegration.Application.DTOs.ETender.SPH.NonNetwork
{
    public class SPHNonShoppingListNonNetworkNegotiation
    {
        [Key]
        public int ID { get; set; }
        public int SPHNonNetworkWorkTypePriceID { get; set; }
        public decimal Price { get; set; }
        public bool? IsNegotiation { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsSync { get; set; }
        public DateTime? SyncDate { get; set; }
    }
}
