namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.Traveloka
{
    public class vmAccomAffiliateChargeableRate
    {
        public string? currencyCode { get; set; }
        public string? averageBaseRate { get; set; }
        public string? averageRate { get; set; }
        public string? nightlyRateTotal { get; set; }
        public string? surchargeTotal { get; set; }
        public string? total { get; set; }
        public List<vmAccomAffiliateSurcharge> surcharges { get; set; }
        public List<vmAccomAffiliateNightlyRate> nightlyRates { get; set; }
        public string? chargeableRateInfo { get; set; }
        public string? recommendedSellingPrice { get; set; }
    }
}
