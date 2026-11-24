using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Application.DTOs.VendorRegistration
{
    public class CompanyContactPersonDto
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string MobilePhone { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;

        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public string CreatedDate { get; set; } = string.Empty;
        public string UpdatedBy { get; set; } = string.Empty;
        public string UpdatedDate { get; set; } = string.Empty;
    }
}