using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent
{
    public class dtPostApiLog<TLog>
    {
        public int BookingCoreID { get; set; }
        public string EndpointCode { get; set; }
        public string LogPath { get; set; }
        public TLog Log { get; set; }
    }
}
