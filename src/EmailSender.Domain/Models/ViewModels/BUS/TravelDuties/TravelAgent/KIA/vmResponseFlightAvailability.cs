using DataIntegration.Domain.Models.Abstracts;

namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.KIA
{
    public class vmResponseFlightAvailability : BaseClass
    {
        public vmResponseFlightAvailability()
        {
            ErrorType = 0;
            ErrorMessage = string.Empty;
            Schedules = new List<vmResponseFlightAvailabilitySchedule>();
            AirportDetails = new List<vmResponseFlightAvailabilityAirportDetail>();
            AirportV2Details = new List<vmResponseFlightAvailabilityAirportV2Detail>();
        }

        public vmResponseFlightAvailability(int errorType, string? errorMessage)
        {
            ErrorType = errorType;
            ErrorMessage = errorMessage;
            Schedules = new List<vmResponseFlightAvailabilitySchedule>();
            AirportDetails = new List<vmResponseFlightAvailabilityAirportDetail>();
            AirportV2Details = new List<vmResponseFlightAvailabilityAirportV2Detail>();
        }

        public List<vmResponseFlightAvailabilitySchedule> Schedules { get; set; }
        public List<vmResponseFlightAvailabilityAirportDetail> AirportDetails { get; set; }
        public List<vmResponseFlightAvailabilityAirportV2Detail> AirportV2Details { get; set; }
        public string? Message { get; set; }
    }

    public class vmResponseFlightAvailabilitySchedule
    {
        public vmResponseFlightAvailabilitySchedule()
        {
            Flights = new List<vmResponseFlightAvailabilityFlight>();
        }

        public string? Origin { get; set; }
        public string? Destination { get; set; }
        public bool IsInternational { get; set; }
        public List<vmResponseFlightAvailabilityFlight> Flights { get; set; }
        public int HaveUpdate { get; set; }
    }

    public class vmResponseFlightAvailabilityFlight
    {
        public vmResponseFlightAvailabilityFlight()
        {
            ClassObjects = new List<vmResponseFlightAvailabilityClassObject>();
            ConnectingFlights = new List<vmResponseFlightAvailabilityFlight>();
            FareBreakdowns = new List<vmResponseFlightAvailabilityFareBreakdowns>();
            Facilities = new List<vmResponseFlightAvailabilityFacilities>();
            Aircraft = new vmResponseFlightAvailabilityAircraft();
        }

        public string? Id { get; set; }
        public string? GroupingId { get; set; }
        public int Airline { get; set; }
        public string? AirlineImageUrl { get; set; }
        public string? AirlineName { get; set; }
        public string? Number { get; set; }
        public string? OperatingNumber { get; set; }
        public string? OperatingAirlineImageUrl { get; set; }
        public string? OperatingAirlineName { get; set; }
        public string? Origin { get; set; }
        public string? OriginTerminal { get; set; }
        public string? Destination { get; set; }
        public string? DestinationTerminal { get; set; }
        public decimal Fare { get; set; }
        public string? FareType { get; set; }
        public bool IsMultiClass { get; set; }
        public bool IsConnecting { get; set; }
        public bool IsAvailable { get; set; }
        public string? FlightType { get; set; }
        public string? DepartDate { get; set; }
        public string? DepartTime { get; set; }
        public string? ArriveDate { get; set; }
        public string? ArriveTime { get; set; }
        public string? Duration { get; set; }
        public int TotalTransit { get; set; }
        public List<vmResponseFlightAvailabilityClassObject> ClassObjects { get; set; }
        public List<vmResponseFlightAvailabilityFlight> ConnectingFlights { get; set; }
        public List<vmResponseFlightAvailabilityFareBreakdowns> FareBreakdowns { get; set; }
        public List<vmResponseFlightAvailabilityFacilities> Facilities { get; set; }
        public string? PriceFare { get; set; }
        public bool IsOpenJawTransit { get; set; }
        public string? Note { get; set; }
        public vmResponseFlightAvailabilityAircraft Aircraft { get; set; }
        public string? ExtraData { get; set; }
    }

    public class vmResponseFlightAvailabilityClassObject
    {
        public string? Id { get; set; }
        public string? FlightId { get; set; }
        public string? Code { get; set; }
        public string? Category { get; set; }
        public int Seat { get; set; }
        public decimal Fare { get; set; }
        public decimal Tax { get; set; }
        public string? FareBasisCode { get; set; }
        public string? FareRuleKeys { get; set; }
        public string? SegmentSellKey { get; set; }
        public string? ExtraData { get; set; }
        public int Variant { get; set; }
        public string? ClassGroupId { get; set; }
        public string? TransitTime { get; set; }
        public string? FareDesign { get; set; }
    }

    public class vmResponseFlightAvailabilityFareBreakdowns
    {
        public vmResponseFlightAvailabilityFareBreakdowns()
        {
            Charges = new List<vmResponseFlightAvailabilityCharges>();
        }
        public string? PaxType { get; set; }
        public List<vmResponseFlightAvailabilityCharges> Charges { get; set; }
    }

    public class vmResponseFlightAvailabilityCharges
    {
        public string? Code { get; set; }
        public decimal Amount { get; set; }
        public string? Currency { get; set; }
        public decimal ForeignAmount { get; set; }
        public string? ForeignCurrency { get; set; }
        public string? ClassId { get; set; }
        public string? FlightId { get; set; }
    }

    public class vmResponseFlightAvailabilityFacilities
    {
        public string? Category { get; set; }
        public string? Value { get; set; }
    }

    public class vmResponseFlightAvailabilityAircraft
    {
        public string? Code { get; set; }
        public string? ShortName { get; set; }
        public string? LongName { get; set; }
    }


    public class vmResponseFlightAvailabilityAirportDetail
    {
        public string? Code { get; set; }
        public string? CountryCode { get; set; }
        public string? CityName { get; set; }
        public string? AirportName { get; set; }
        public decimal Locale { get; set; }
        public bool Active { get; set; }
        public string? CountryName { get; set; }
        public bool IsNonGds { get; set; }
        public bool IsGds { get; set; }
        public string? ForOverride { get; set; }
        public string? LocalView { get; set; }
    }

    public class vmResponseFlightAvailabilityAirportV2Detail
    {
        public string? Iata { get; set; }
        public string? Name { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? CountryName { get; set; }
        public bool IsGds { get; set; }
        public bool IsNonGds { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string? TimeZoneZdb { get; set; }
        public string? MinOffset { get; set; }
        public string? MaxOffset { get; set; }
    }
}
