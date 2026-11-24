using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Application.DTOs.VendorRegistration
{
    public class FormProgress
    {
        public int CompanyID { get; set; }

        public int CurrentModule { get; set; }

        public bool? IsActive { get; set; }

        public bool IsSync { get; set; }

        public DateTime? DateTimeSync { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
