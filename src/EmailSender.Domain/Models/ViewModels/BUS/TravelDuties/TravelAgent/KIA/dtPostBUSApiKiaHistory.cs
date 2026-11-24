namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.KIA
{
    public class dtPostBUSApiKiaHistory
    {
        public long? ApiKiaHistoryID { get; set; }
        public string? Token { get; set; }
        public DateTime? SentDate { get; set; }
        public string? Url { get; set; }
        public string? Request { get; set; }
        public string? Response { get; set; }
        public int? StatusID { get; set; }
        public int? APIStatusCode { get; set; }
    }
}
