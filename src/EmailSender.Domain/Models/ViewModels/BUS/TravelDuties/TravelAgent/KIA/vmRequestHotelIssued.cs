using DataIntegration.Domain.Models.Abstracts;

namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.KIA
{
    public class vmRequestHotelIssued : BaseClass
    {
        public vmRequestHotelIssued()
        {
            ErrorType = 0;
            ErrorMessage = string.Empty;
            Contact = new vmRequestHotelIssuedContact();
            Guests = new List<vmRequestHotelIssuedGuest>();
            Beds = new List<vmRequestHotelIssuedBed>();
        }

        public vmRequestHotelIssued(int errorType, string? errorMessage)
        {
            ErrorType = errorType;
            ErrorMessage = errorMessage;
            Contact = new vmRequestHotelIssuedContact();
            Guests = new List<vmRequestHotelIssuedGuest>();
            Beds = new List<vmRequestHotelIssuedBed>();
        }

        public string? CorrelationId { get; set; }
        public string? ConfirmationId { get; set; }
        public vmRequestHotelIssuedContact Contact { get; set; }
        public List<vmRequestHotelIssuedGuest> Guests { get; set; }
        public List<vmRequestHotelIssuedBed> Beds { get; set; }
    }

    public class vmRequestHotelIssuedContact
    {
        public string? Title { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MobilePhone { get; set; }
        public string? HomePhone { get; set; }
        public string? Email { get; set; }
        public string? Remark { get; set; }
    }

    public class vmRequestHotelIssuedGuest
    {
        public int Index { get; set; }
        public string? Title { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MobilePhone { get; set; }
        public string? HomePhone { get; set; }
        public string? Email { get; set; }
        public int Age { get; set; }
        public int Type { get; set; }
        public int AssignedRoom { get; set; }
        public int OrderInRoom { get; set; }
    }

    public class vmRequestHotelIssuedBed
    {
        public int Index { get; set; }
        public int CountAdult { get; set; }
        public bool RequestChildBed { get; set; }
        public string? Type { get; set; }
    }
}