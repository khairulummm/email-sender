using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Application.DTOs.VendorRegistration
{
    public class CompanyQHSEDocumentCorporateDto
    {
        public int ID { get; set; }
        public IdNameDto Certificate { get; set; } = new IdNameDto();
        public string CertificateNumber { get; set; } = string.Empty;
        public string ValidFrom { get; set; } = string.Empty;
        public string ValidUntil { get; set; } = string.Empty;
        public string CertificationInstitute { get; set; } = string.Empty;
        public string OriginalFileName { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        public IdNameDto CoreBusinessID { get; set; } = new IdNameDto();
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public string CreatedDate { get; set; } = string.Empty;
        public string UpdatedBy { get; set; } = string.Empty;
        public string UpdatedDate { get; set; } = string.Empty;
    }
}
