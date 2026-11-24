namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.KIA
{
    public class dtPostBUSKiaAirport
    {
        public int? KiaAirportID { get; set; }
        public string? Code { get; set; }
        public string? CityName { get; set; }
        public string? CountryCode { get; set; }
        public string? AirportName { get; set; }
        public decimal? Locale { get; set; }
        public bool? IsNonGds { get; set; }
        public bool? IsGds { get; set; }
        public bool? ForOverride { get; set; }
        public bool? IsActive { get; set; }
    }
}
