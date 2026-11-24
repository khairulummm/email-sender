using DataIntegration.Domain.Models.Abstracts;

namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties
{
    public class vmTravelDutiesBookingAccommodationStatus : BaseClass
    {
        public vmTravelDutiesBookingAccommodationStatus()
        {
            ErrorType = 0;
            ErrorMessage = string.Empty;
        }

        public vmTravelDutiesBookingAccommodationStatus(int errorType, string? errorMessage)
        {
            ErrorType = errorType;
            ErrorMessage = errorMessage;
        }

        public long TravelDutiesID { get; set; }
        public string TravelDutiesNumber { get; set; }
        public string ApplicantID { get; set; }
        public long? OtherTravelDutiesID { get; set; }
        public string OtherTravelDutiesNumber { get; set; }
        public string OtherApplicantID { get; set; }
        public int BookingAccommodationID { get; set; }
        public string AcommodationID { get; set; }
        public string AcommodationName { get; set; }
        public string RoomName { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int TravelAgentID { get; set; }
        public string TravelAgent { get; set; }
        public string BookingStatus { get; set; }
        public string JsonErrMessage { get; set; }
        public bool? IsSuccess { get; set; }
        public int? StatusCode { get; set; }
    }
}
