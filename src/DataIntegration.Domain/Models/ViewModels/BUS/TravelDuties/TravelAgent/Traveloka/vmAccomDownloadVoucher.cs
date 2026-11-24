using DataIntegration.Domain.Models.Abstracts;

namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.Traveloka
{
    public class vmAccomDownloadVoucher : BaseClass
    {
        public vmAccomDownloadVoucher()
        {
            ErrorType = 0;
            ErrorMessage = "";
        }
        public vmAccomDownloadVoucher(int errorType, string? errorMessage, int statusCode)
        {
            ErrorType = errorType;
            ErrorMessage = errorMessage;
            APIStatusCode = statusCode;
        }

        public string? data { get; set; }
        public string? fileName { get; set; }
        public string? errorType { get; set; }
        public string? errorMessage { get; set; }

        public int? APIStatusCode { get; set; }
        public int? ErrorType { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
