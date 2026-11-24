using DataIntegration.Domain.Models.Abstracts;

namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.KIA
{
    public class vmResponseHotelIssued : BaseClass
    {
        public vmResponseHotelIssued()
        {
            ErrorType = 0;
            ErrorMessage = string.Empty;
        }

        public vmResponseHotelIssued(int errorType, string? errorMessage)
        {
            ErrorType = errorType;
            ErrorMessage = errorMessage;
        }

        public string? PnrId { get; set; }
        public bool IsError { get; set; }
        public string? Message { get; set; }
        public string? StackTrace { get; set; }
        public List<vmResponseHotelIssuedError> Errors { get; set; }
    }

    public class vmResponseHotelIssuedError
    {
        public string? Property { get; set; }
        public string? Message { get; set; }
    }

}
