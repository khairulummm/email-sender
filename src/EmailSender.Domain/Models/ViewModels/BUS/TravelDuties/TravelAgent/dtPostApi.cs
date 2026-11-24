using RestSharp;

namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent
{
    public class dtPostApi<TModel>
    {
        public int BookingCoreID { get; set; }
        public string Host { get; set; }
        public string UserID { get; set; }
        public string LogPath { get; set; }
        public TModel Model { get; set; }
        public Method Method { get; set; }

        public string SchedullerID { get; set; }
    }
}
