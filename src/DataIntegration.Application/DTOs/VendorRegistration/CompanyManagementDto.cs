using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Application.DTOs.VendorRegistration
{
    public class CompanyManagementDto
    {
        public int ID { get; set; }
        public string PresidentDirectorName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string BirthDay { get; set; } = string.Empty;
        public string MobilePhoneNumber { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public string AlternativeEmailAddress { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public string CreatedDate { get; set; } = string.Empty;
        public string UpdatedBy { get; set; } = string.Empty;
        public string UpdatedDate { get; set; } = string.Empty;
    }
}
