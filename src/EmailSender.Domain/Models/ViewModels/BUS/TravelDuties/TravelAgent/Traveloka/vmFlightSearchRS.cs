using DataIntegration.Domain.Models.Abstracts;

namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.Traveloka
{
    public class vmFlightSearchRS //: BaseClass
    {
        //public vmFlightSearchRS()
        //{
        //    this.ErrorType = 0;
        //    this.ErrorMessage = "";
        //}
        //public vmFlightSearchRS(int errorType, string? errorMessage)
        //{
        //    this.ErrorType = errorType;
        //    this.ErrorMessage = errorMessage;
        //}

        public bool success { get; set; }
        public string? errorMessage { get; set; }
        public vmFlightSearchData data { get; set; }
    }

    public class vmFlightSearchData
    {
        public bool completed { get; set; }
        public List<vmFlightSearchResult> oneWayFlightSearchResults { get; set; }
    }

    public class vmFlightSearchResult : BaseClass
    {
        public vmFlightSearchResult()
        {
            ErrorType = 0;
            ErrorMessage = "";
        }
        public vmFlightSearchResult(int errorType, string? errorMessage)
        {
            ErrorType = errorType;
            ErrorMessage = errorMessage;
        }

        public string? flightId { get; set; }
        public string? departureAirport { get; set; }
        public string? arrivalAirport { get; set; }
        public string? numOfTransits { get; set; }
        public string? tripDuration { get; set; }
        public List<vmFlightJourney> journeys { get; set; }
    }

    public class vmFlightJourney
    {
        public List<vmSegment> segments { get; set; }
        public vmDeparture departureDetail { get; set; }
        public vmArrival arrivalDetail { get; set; }
        public string? numOfTransits { get; set; }
        public string? journeyDuration { get; set; }
        public vmFareInfo fareInfo { get; set; }
        public string? daysOffset { get; set; }
        public string? refundableStatus { get; set; }
    }

    public class vmDeparture
    {
        public string? airportCode { get; set; }
        public string? departureDate { get; set; }
        public string? departureTime { get; set; }
        public string? departureTerminal { get; set; }
    }

    public class vmArrival
    {
        public string? airportCode { get; set; }
        public string? arrivalDate { get; set; }
        public string? arrivalTime { get; set; }
        public string? arrivalTerminal { get; set; }
    }

    public class vmFareInfo
    {
        public vmFare partnerFare { get; set; }
        public vmFare airlineFare { get; set; }
        public vmNetToAgent netToAgent { get; set; }
    }

    public class vmFare
    {
        public vmPersonFare adultFare { get; set; }
        public vmPersonFare childFare { get; set; }
        public vmPersonFare infantFare { get; set; }
    }

    public class vmPersonFare
    {
        public vmAmount baseFareWithCurrency { get; set; }
        public vmAmount vatWithCurrency { get; set; }
        public vmAmount pscWithCurrency { get; set; }
        public vmAmount fuelSurchargeWithCurrency { get; set; }
        public vmAmount adminFeeWithCurrency { get; set; }
        public vmAmount additionalFeeWithCurrency { get; set; }
        public vmAmount totalFareWithCurrency { get; set; }
    }

    public class vmAmount
    {
        public string? amount { get; set; }
        public string? currency { get; set; }
    }

    public class vmNetToAgent
    {
        public vmAmount adultFare { get; set; }
        public vmAmount childFare { get; set; }
        public vmAmount infantFare { get; set; }
    }

    public class vmSegment
    {
        public string? flightCode { get; set; }
        public string? marketingAirline { get; set; }
        public string? brandAirline { get; set; }
        public string? operatingAirline { get; set; }
        public string? subClass { get; set; }
        public string? seatClass { get; set; }
        public string? flightDurationInMinutes { get; set; }
        public string? transitDurationInMinutes { get; set; }
        public vmDeparture departureDetail { get; set; }
        public vmArrival arrivalDetail { get; set; }
        public vmStopInfo stopInfo { get; set; }
        public vmAddOns addOns { get; set; }
    }

    public class vmAddOns
    {
        public List<vmBaggageOptions> baggageOptions { get; set; }
        public List<vmMealOption> mealOptions { get; set; }
        public string? fareBasisCode { get; set; }
    }

    public class vmBaggageOptions
    {
        public string? id { get; set; }
        public string? baggageType { get; set; }
        public string? baggageQuantity { get; set; }
        public string? baggageWeight { get; set; }
        public vmAmount priceWithCurrency { get; set; }
    }

    public class vmStopInfo
    {
        public string? airportCode { get; set; }
        public string? durationMinutes { get; set; }
    }

    public class vmMealOption
    {
        public string? id { get; set; }
        public string? quantity { get; set; }
        public string? displayName { get; set; }
        public vmAmount priceWithCurrency { get; set; }
    }
}
