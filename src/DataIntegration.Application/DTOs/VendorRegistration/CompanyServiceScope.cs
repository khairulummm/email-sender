using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Application.DTOs.VendorRegistration
{
    public class CompanyServiceScope
    {
        public int ID { get; set; }

        public int CompanyID { get; set; }

        public int ServiceScopeID { get; set; }

        public string? AdditionalServiceInformation { get; set; }

        public bool? IsActive { get; set; }

        public string? CreatedBy { get; set; } = default!;

        public DateTime? CreatedDate { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
