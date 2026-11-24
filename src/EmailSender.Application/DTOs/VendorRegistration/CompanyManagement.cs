using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Application.DTOs.VendorRegistration
{
    public class CompanyManagement
    {
        public int ID { get; set; }
        public int CompanyID { get; set; }
        public string? PresidentDirectorName { get; set; }
        public string? Position { get; set; }
        public DateTime? BirthDay { get; set; }
        public string? MobilePhoneNumber { get; set; }
        public string? EmailAddress { get; set; }
        public string? AlternativeEmailAddress { get; set; }
        public string? FilePath { get; set; }
        public bool? IsActive { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
