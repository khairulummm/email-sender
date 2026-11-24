using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Application.DTOs.VendorRegistration
{
    [Table("Company", Schema = "dbo")]
    public class Company
    {
        [Key]
        public int ID { get; set; }
        public string? AspNetUserID { get; set; }
        public string? CompanyName { get; set; }
        public DateTime? DateOfEstablishment { get; set; }
        public int? CompanyTypeID { get; set; }
        public int? OfficeStatusID { get; set; }
        public int? TypeBusinessLicenseID { get; set; }
        public int? CompanyBusinessTypeID { get; set; }
        public int? CompanyQualificationID { get; set; }
        public string? OtherCompanyQualification { get; set; }
        public string? BusinessLicenseNumber { get; set; }
        public DateTime? TaxableBusinessDate { get; set; }
        public string? NPWP { get; set; }
        public string? Website { get; set; }
        public string? CompanyLogo { get; set; }
        public string? PhoneNumber { get; set; }
        public string? FaxNumber { get; set; }
        public string? NpwpAddress { get; set; }
        public DateTime? SubmittedDate { get; set; }
        public bool? IsActive { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
