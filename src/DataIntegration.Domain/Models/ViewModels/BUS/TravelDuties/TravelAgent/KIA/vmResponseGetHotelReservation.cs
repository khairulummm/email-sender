using DataIntegration.Domain.Models.Abstracts;

namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.KIA
{
    public class vmResponseGetHotelReservation : BaseClass
    {
        public vmResponseGetHotelReservation()
        {
            ErrorType = 0;
            ErrorMessage = string.Empty;
            Contact = new vmRequestHotelIssuedContact();
            Passengers = new List<vmResponseGetHotelReservationPassenger>();
            Payments = new List<vmResponseGetHotelReservationPassengerPayment>();
            HotelInformation = new vmResponseGetHotelReservationPassengerHotelInformation();
            Remarks = new List<vmResponseGetHotelReservationRemark>();
        }

        public vmResponseGetHotelReservation(int errorType, string? errorMessage)
        {
            ErrorType = errorType;
            ErrorMessage = errorMessage;
            Contact = new vmRequestHotelIssuedContact();
            Passengers = new List<vmResponseGetHotelReservationPassenger>();
            Payments = new List<vmResponseGetHotelReservationPassengerPayment>();
            HotelInformation = new vmResponseGetHotelReservationPassengerHotelInformation();
            Remarks = new List<vmResponseGetHotelReservationRemark>();
        }
        public string? Id { get; set; }
        public string? ProviderCode { get; set; }
        public string? Source { get; set; }
        public string? BookingCode { get; set; }
        public string? BookingId { get; set; }
        public DateTime? TimeLimit { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Reserved { get; set; }
        public DateTime? Ticketed { get; set; }
        public string? Status { get; set; }
        public string? BosInvoiceNo { get; set; }
        public vmRequestHotelIssuedContact Contact { get; set; }
        public List<vmResponseGetHotelReservationPassenger> Passengers { get; set; }
        public List<vmResponseGetHotelReservationPassengerPayment> Payments { get; set; }
        public vmResponseGetHotelReservationPassengerHotelInformation HotelInformation { get; set; }
        public string? Histories { get; set; }
        public List<vmResponseGetHotelReservationRemark> Remarks { get; set; }
        public string? EssentialInformation { get; set; }
        public string? Message { get; set; }
    }

    public class vmResponseGetHotelReservationPassenger
    {
        public vmResponseGetHotelReservationPassenger()
        {
            Passport = new vmResponseGetHotelReservationPassengerPassport();
        }

        public int Index { get; set; }
        public string? Type { get; set; }
        public string? Title { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? BirthDate { get; set; }
        public string? HomePhone { get; set; }
        public string? MobilePhone { get; set; }
        public string? OtherPhone { get; set; }
        public string? Nationality { get; set; }
        public string? IdNumber { get; set; }
        public vmResponseGetHotelReservationPassengerPassport Passport { get; set; }
        public string? TicketNumber { get; set; }
        public int AssignedRoom { get; set; }
        public int OrderInRoom { get; set; }
    }

    public class vmResponseGetHotelReservationPassengerPassport
    {
        public string? Number { get; set; }
        public string? OriginCountry { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Expire { get; set; }
    }

    public class vmResponseGetHotelReservationPassengerPayment
    {
        public string? Code { get; set; }
        public string? Title { get; set; }
        public decimal Amount { get; set; }
        public string? Currency { get; set; }
        public decimal ForeignAmount { get; set; }
        public string? ForeignCurrency { get; set; }
    }

    public class vmResponseGetHotelReservationPassengerHotelInformation
    {
        public vmResponseGetHotelReservationPassengerHotelInformation()
        {
            CancellationPolicy = new List<string>();
        }
        public string? HotelName { get; set; }
        public string? CityName { get; set; }
        public string? CityCode { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int NightStay { get; set; }
        public string? RoomCategory { get; set; }
        public string? RoomType { get; set; }
        public string? Meal { get; set; }
        public string? Address { get; set; }
        public string? Remark { get; set; }
        public string? MapsUri { get; set; }
        public string? StarLevel { get; set; }
        public string? IsGuaranted { get; set; }
        public string? IsWithBreakfast { get; set; }
        public string? CancellationCharge { get; set; }
        public List<string> CancellationPolicy { get; set; }
    }

    public class vmResponseGetHotelReservationRemark
    {
        public int Index { get; set; }
        public int PaxIndex { get; set; }
        public string? Body { get; set; }
    }

}
