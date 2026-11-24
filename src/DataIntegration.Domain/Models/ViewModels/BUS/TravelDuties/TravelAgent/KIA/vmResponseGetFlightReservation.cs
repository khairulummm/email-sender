using DataIntegration.Domain.Models.Abstracts;

namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.KIA
{
    public class vmResponseGetFlightReservation : BaseClass
    {
        public vmResponseGetFlightReservation()
        {
            ErrorType = 0;
            ErrorMessage = string.Empty;
        }

        public vmResponseGetFlightReservation(int errorType, string? errorMessage)
        {
            ErrorType = errorType;
            ErrorMessage = errorMessage;
        }

        public string? Id { get; set; }
        public int Airline { get; set; }
        public string? BookingCode { get; set; }
        public DateTime? TimeLimit { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Reserved { get; set; }
        public DateTime? Ticketed { get; set; }
        public string? Status { get; set; }
        public string? BosInvoiceNo { get; set; }
        public List<vmResponseGetFlightReservationSegment> Segments { get; set; }
        public vmResponseGetFlightReservationContact Contact { get; set; }
        public List<vmResponseGetFlightReservationPassenger> Passengers { get; set; }
        public List<vmResponseGetFlightReservationPayment> Payments { get; set; }
        public List<vmResponseGetFlightReservationFlightDetail> FlightDetails { get; set; }
        //public object DiscountInfo { get; set; }
        //public object PaymentTransactionInfo { get; set; }
        //public object SqlDiscountInfo { get; set; }
        //public object SqlPaymentInfo { get; set; }
        //public object Histories { get; set; }
        //public object Remarks { get; set; }
        public string? Message { get; set; }
    }

    public class vmResponseGetFlightReservationSegment
    {
        public string? AirlineName { get; set; }
        public string? Origin { get; set; }
        public string? Destination { get; set; }
        public string? OriginAirport { get; set; }
        public string? DestinationAirport { get; set; }
        public string? AirlineBookingCode { get; set; }
        public int Num { get; set; }
        public int Seq { get; set; }
    }

    public class vmResponseGetFlightReservationContact
    {
        public string? Title { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? MobilePhone { get; set; }
        public string? HomePhone { get; set; }
    }

    public class vmResponseGetFlightReservationPassenger
    {
        public int Index { get; set; }
        public string? Type { get; set; }
        public string? Title { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Gender { get; set; }
        public string? HomePhone { get; set; }
        public string? MobilePhone { get; set; }
        public string? OtherPhone { get; set; }
        public string? Nationality { get; set; }
        public string? IdentityType { get; set; }
        public string? IdNumber { get; set; }
        public string? EmergencyFullName { get; set; }
        public string? EmergencyPhone { get; set; }
        public string? EmergencyEmail { get; set; }
        public vmResponseGetFlightReservationPassengerPassport Passport { get; set; }
        public string? TicketNumber { get; set; }
        public List<vmResponseGetFlightReservationPassengerSsr> Ssrs { get; set; }
        public List<vmResponseGetFlightReservationPassengerSsr> Seats { get; set; }
        //public object FrequentFlyer { get; set; }
        //public List<object> SegmentBaggages { get; set; }
    }

    public class vmResponseGetFlightReservationPassengerPassport
    {
        public string? Number { get; set; }
        public string? OriginCountry { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? Expire { get; set; }
    }

    public class vmResponseGetFlightReservationPassengerSsr
    {
        public string? SsrCode { get; set; }
        public string? OriginCode { get; set; }
        public string? DestinationCode { get; set; }
        public decimal SsrFare { get; set; }
        public string? Ccy { get; set; }
        public string? SsrName { get; set; }
        public int SsrType { get; set; }
        public string? FlightNumber { get; set; }
        public string? PaxType { get; set; }
        public decimal? Quantity { get; set; }
        public string? Image { get; set; }
        public string? ShortDesc { get; set; }
        public string? LongDesc { get; set; }
        public decimal Tax { get; set; }
    }

    public class vmResponseGetFlightReservationPayment
    {
        public string? Code { get; set; }
        public string? Title { get; set; }
        public decimal Amount { get; set; }
        public string? Currency { get; set; }
        public decimal ForeignAmount { get; set; }
        public string? ForeignCurrency { get; set; }
    }

    public class vmResponseGetFlightReservationFlightDetail
    {
        public int Airline { get; set; }
        public string? FlightNumber { get; set; }
        public string? OperatingFlightNumber { get; set; }
        public string? OperatingAirline { get; set; }
        public string? CarrierCode { get; set; }
        public string? Origin { get; set; }
        public string? Destination { get; set; }
        public string? DepartDate { get; set; }
        public string? DepartTime { get; set; }
        public string? ArriveDate { get; set; }
        public string? ArriveTime { get; set; }
        public string? Duration { get; set; }
        public int Num { get; set; }
        public int Seq { get; set; }
        public string? Class { get; set; }
        public string? Category { get; set; }
        public string? AirlineImageUrl { get; set; }
        public string? OperatingAirlineImageUrl { get; set; }
    }
}
