using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Application.DTOs.VendorRegistration
{
    public class CompanyServiceScopeRegionCapacityDto
    {
        public int ID { get; set; }
        public IdNameDto CompanyServiceScope { get; set; } = new IdNameDto();
        public IdNameDto Region { get; set; } = new IdNameDto();
        public decimal Capacity { get; set; }
        public string UoM { get; set; } = string.Empty;
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public string CreatedDate { get; set; } = string.Empty;
        public string UpdatedBy { get; set; } = string.Empty;
        public string UpdatedDate { get; set; } = string.Empty;
    }
}
