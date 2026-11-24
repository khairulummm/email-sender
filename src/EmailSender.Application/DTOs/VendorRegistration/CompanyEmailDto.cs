using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Application.DTOs.VendorRegistration
{
    public class CompanyEmailGroupDto
    {
        public List<CompanyEmailItemDto> Correspondence { get; set; } = new List<CompanyEmailItemDto>();
        public List<CompanyEmailItemDto> Finance { get; set; } = new List<CompanyEmailItemDto>();
    }

    public class CompanyEmailItemDto
    {
        public int ID { get; set; }
        public string Email { get; set; } = string.Empty;
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public string CreatedDate { get; set; } = string.Empty;
        public string UpdatedBy { get; set; } = string.Empty;
        public string UpdatedDate { get; set; } = string.Empty;
    }
}
