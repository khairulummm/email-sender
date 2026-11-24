using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Application.DTOs.VendorRegistration
{
    public class CoreBusiness
    {
        public int ID { get; set; }

        public string CoreBusinessCode { get; set; }

        public string CoreBusinessName { get; set; }

        public bool? IsActive { get; set; }
        public string? UnitID { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
