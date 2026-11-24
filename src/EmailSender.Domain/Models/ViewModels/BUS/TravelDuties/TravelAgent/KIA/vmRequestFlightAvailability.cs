using DataIntegration.Domain.Models.Abstracts;

namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.KIA
{
    public class vmRequestFlightAvailability : BaseClass
    {
        public vmRequestFlightAvailability()
        {
            ErrorType = 0;
            ErrorMessage = string.Empty;
            Routes = new List<vmRequestFlightAvailabilityRoute>();
        }

        public vmRequestFlightAvailability(int errorType, string? errorMessage)
        {
            ErrorType = errorType;
            ErrorMessage = errorMessage;
            Routes = new List<vmRequestFlightAvailabilityRoute>();
        }
        public List<vmRequestFlightAvailabilityRoute> Routes { get; set; }
        public int Adult { get; set; }
        public int Child { get; set; }
        public int Infant { get; set; }
        public string? FareType { get; set; }
        public int[] PreferredAirlines { get; set; }
        public int[] PreferredCarriers { get; set; }
        //public string? RequestId { get; set; }
        //public string? EmptyPerAirlineCallbackUrl { get; set; }
        //public string? CabinClass { get; set; }
        //public string[] CabinClasses { get; set; }
    }

    public class vmRequestFlightAvailabilityRoute
    {
        public string? Origin { get; set; }
        public string? Destination { get; set; }
        public DateTime DepartDate { get; set; }
    }

}
