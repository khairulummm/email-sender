using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Application.DTOs.VendorRegistration
{
    public class CompanyBranchOfficesDto
    {
        public int ID { get; set; }
        public IdNameDto? Regional { get; set; }
        public string Address { get; set; } = string.Empty;
        public string OfficePhone { get; set; } = string.Empty;
        public string PICName { get; set; } = string.Empty;
        public string PICMobilePhone { get; set; } = string.Empty;

        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public string CreatedDate { get; set; } = string.Empty;
        public string UpdatedBy { get; set; } = string.Empty;
        public string UpdatedDate { get; set; } = string.Empty;
    }
}