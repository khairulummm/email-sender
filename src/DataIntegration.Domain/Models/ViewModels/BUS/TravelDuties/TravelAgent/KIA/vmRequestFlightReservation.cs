using DataIntegration.Domain.Models.Abstracts;

namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.KIA
{
    public class vmRequestFlightReservation : BaseClass
    {
        public vmRequestFlightReservation()
        {
            ErrorType = 0;
            ErrorMessage = string.Empty;
            Contact = new vmRequestFlightReservationContact();
            Passengers = new List<vmRequestFlightReservationPassenger>();
            Segments = new List<vmRequestFlightReservationSegment>();
        }

        public vmRequestFlightReservation(int errorType, string? errorMessage)
        {
            ErrorType = errorType;
            ErrorMessage = errorMessage;
            Contact = new vmRequestFlightReservationContact();
            Passengers = new List<vmRequestFlightReservationPassenger>();
            Segments = new List<vmRequestFlightReservationSegment>();
        }

        public vmRequestFlightReservationContact Contact { get; set; }
        public List<vmRequestFlightReservationPassenger> Passengers { get; set; }
        public List<vmRequestFlightReservationSegment> Segments { get; set; }
        public string? CallbackUri { get; set; }
        public string? FlightType { get; set; }
    }

    public class vmRequestFlightReservationContact
    {
        public string? Email { get; set; }
        public string? Title { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? HomePhone { get; set; }
        public string? MobilePhone { get; set; }
    }

    public class vmRequestFlightReservationPassenger
    {
        public int Index { get; set; }
        public int Type { get; set; }
        public string? Title { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool IsSeniorCitizen { get; set; }
        public string? BirthDate { get; set; }
        public string? Email { get; set; }
        public string? HomePhone { get; set; }
        public string? MobilePhone { get; set; }
        public string? OtherPhone { get; set; }
        public string? IdNumber { get; set; }
        public string? Nationality { get; set; }
        public int? AdultAssoc { get; set; }
        public string? PassportNumber { get; set; }
        public DateTime? PassportExpire { get; set; }
        public string? PassportOrigin { get; set; }
        public string? EmergencyFullName { get; set; }
        public string? EmergencyPhone { get; set; }
        public string? EmergencyEmail { get; set; }
        public List<vmRequestFlightReservationSeats> Seats { get; set; }
        public List<vmRequestFlightReservationService> Ssrs { get; set; }
    }

    public class vmRequestFlightReservationSeats
    {
        public string? Availability { get; set; }
        public string? Ccy { get; set; }
        public string? FlightNumber { get; set; }
        public int SeatFare { get; set; }
        public string? SeatNumber { get; set; }
        public string? SeatType { get; set; }
        public string? SeatCode { get; set; }
        public string? SeatClass { get; set; }
        public int SeatGroup { get; set; }
        public string? SeatClassCode { get; set; }
        public string? SeatRowSet { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public vmRequestFlightReservationSeatsProp Properties { get; set; }
    }

    public class vmRequestFlightReservationSeatsProp
    {
        public string? INFANT { get; set; }
        public string? TCC { get; set; }
        public string? BRDZONE { get; set; }
    }

    public class vmRequestFlightReservationService
    {
        public string? SsrCode { get; set; }
        public string? OriginCode { get; set; }
        public string? DestinationCode { get; set; }
        public int SsrFare { get; set; }
        public string? Ccy { get; set; }
        public string? SsrName { get; set; }
        public int SsrType { get; set; }
        public string? FlightNumber { get; set; }
    }

    public class vmRequestFlightReservationSegment
    {
        public string? ClassId { get; set; }
        public int Airline { get; set; }
        public string? FlightNumber { get; set; }
        public string? Origin { get; set; }
        public string? DepartDate { get; set; }
        public string? DepartTime { get; set; }
        public string? Destination { get; set; }
        public string? ArriveDate { get; set; }
        public string? ArriveTime { get; set; }
        public string? ClassCode { get; set; }
        public string? FlightId { get; set; }
        public int Num { get; set; }
        public int Seq { get; set; }
    }
}


