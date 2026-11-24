namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.Traveloka
{
    public class vmAccomAffiliateAPIRoomRate
    {
        public string? rateKey { get; set; }
        public string? numOfAdults { get; set; }
        public string? rateType { get; set; }
        public List<vmAccomAffiliateAPIPromo> promos { get; set; }
        public string? currentAllotments { get; set; }
        public string? cancellationPolicyDisplay { get; set; }
        public List<vmAccomAffiliateCancellationPolicy> cancellationPolicies { get; set; }
        public vmAccomAffiliateChargeableRate chargeableRate { get; set; }
        public vmAccomAffiliateChargeableRate convertedChargeableRate { get; set; }
    }
}
