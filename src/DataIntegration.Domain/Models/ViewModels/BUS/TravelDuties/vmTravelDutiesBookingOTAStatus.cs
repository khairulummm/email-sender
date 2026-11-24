using DataIntegration.Domain.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties
{
    public class vmTravelDutiesBookingOTAStatus : BaseClass
    {
        public vmTravelDutiesBookingOTAStatus()
        {
            ErrorType = 0;
            ErrorMessage = string.Empty;
        }

        public vmTravelDutiesBookingOTAStatus(int errorType, string? errorMessage)
        {
            ErrorType = errorType;
            ErrorMessage = errorMessage;
        }
        public long TravelDutiesID { get; set; }
        public string TravelAgent { get; set; }
        public string TravelDutiesNumber { get; set; }
        public string Applicant { get; set; }
        public string ApplicantEmail { get; set; }
        public string BTAName { get; set; }
        public string BTAEmail { get; set; }
        public string BTAPhone { get; set; }
        public List<vmTravelDutiesBookingAccommodationStatus> ListAccommodation { get; set; }
        public List<vmTravelDutiesBookingFlightStatus> ListFlight { get; set; }
    }
}
