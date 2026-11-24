using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Application.DTOs.VendorRegistration
{
    public class CompanyQHSEDocumentPersonal
    {
        public int ID { get; set; }

        public int CompanyID { get; set; }

        public string EmployeeName { get; set; }

        public int CertificateId { get; set; }

        public string CertificateNumber { get; set; }

        public DateTime? ValidFrom { get; set; }

        public DateTime? ValidUntil { get; set; }

        public string CertificationInstitute { get; set; }

        public string OriginalFileName { get; set; }

        public string FilePath { get; set; }

        public bool? IsActive { get; set; }

        public int? CoreBusinessID { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
