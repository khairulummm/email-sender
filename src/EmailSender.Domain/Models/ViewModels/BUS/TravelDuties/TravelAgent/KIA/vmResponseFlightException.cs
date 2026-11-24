using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.KIA
{
    public class vmResponseFlightException
    {
        public string TicketConfirmStatus { get; set; }
        public string Error { get; set; }
        public string Message { get; set; }
    }

    public class vmResponseFlightExceptionMessage
    {
    }
}
