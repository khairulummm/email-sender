using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Application.DTOs.VendorRegistration
{
    public class CompanyServiceScopeRegionCapacity
    {
        public int ID { get; set; }

        public int CompanyServiceScopeID { get; set; }

        public int CompanyID { get; set; }

        public int RegionID { get; set; }

        public int Capacity { get; set; }

        public string? UoM { get; set; }

        public bool? IsActive { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
