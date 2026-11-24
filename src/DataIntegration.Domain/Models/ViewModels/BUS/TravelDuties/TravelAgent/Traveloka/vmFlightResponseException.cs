using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.Traveloka
{
    public class vmFlightResponseException
    {
        //public vmFlightFailBookConfirm()
        //{
        //    ErrorType = 0;
        //    ErrorMessage = "";
        //}
        //public vmFlightFailBookConfirm(int errorType, string? errorMessage, int statusCode)
        //{
        //    ErrorType = errorType;
        //    ErrorMessage = errorMessage;
        //    APIStatusCode = statusCode;
        //}

        public bool success { get; set; }
        public string? errorMessage { get; set; }
        public string? errorType { get; set; }
        public object data { get; set; }

        //public int? APIStatusCode { get; set; }
        //public int? ErrorType { get; set; }
        //public string? ErrorMessage { get; set; }
    }
}
