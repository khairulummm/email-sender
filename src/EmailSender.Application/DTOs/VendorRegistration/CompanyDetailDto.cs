using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Application.DTOs.VendorRegistration
{
    public class CompanyDetailDto
    {
        public int ID { get; set; }
        public string AspNetUserID { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public string UserPhoneNumber { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string DateOfEstablishment { get; set; } = string.Empty;
        public IdNameDto CompanyType { get; set; } = new IdNameDto();
        public IdNameDto OfficeStatus { get; set; } = new IdNameDto();
        public IdNameDto TypeBusinessLicense { get; set; } = new IdNameDto();
        public IdNameDto CompanyBusinessType { get; set; } = new IdNameDto();
        public IdNameDto CompanyQualification { get; set; } = new IdNameDto();
        public string OtherCompanyQualification { get; set; } = string.Empty;
        public string BusinessLicenseNumber { get; set; } = string.Empty;
        public string TaxableBusinessDate { get; set; } = string.Empty;
        public string NPWP { get; set; } = string.Empty;
        public string NpwpAddress { get; set; } = string.Empty;
        public string Website { get; set; } = string.Empty;
        public string CompanyLogo { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string FaxNumber { get; set; } = string.Empty;
        public string SubmittedDate { get; set; } = string.Empty;
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public string CreatedDate { get; set; } = string.Empty;
        public string UpdatedBy { get; set; } = string.Empty;
        public string UpdatedDate { get; set; } = string.Empty;
        public bool IsSync { get; set; } = false;
        public DateTime SyncDate { get; set; } = DateTime.Now;
    }
}
