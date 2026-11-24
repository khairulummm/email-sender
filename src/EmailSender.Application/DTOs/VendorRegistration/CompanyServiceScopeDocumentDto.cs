using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Application.DTOs.VendorRegistration
{
    public class CompanyServiceScopeDocumentDto
    {
        public int ID { get; set; }
        public IdNameDto DocumentId { get; set; } = new IdNameDto();
        public string StartPeriod { get; set; } = string.Empty;
        public string EndPeriod { get; set; } = string.Empty;
        public string AdditionalInformation { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        public string OriginalFileName { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        public List<IdNameDto> CoreBusinessID { get; set; } = new List<IdNameDto>();
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public string CreatedDate { get; set; } = string.Empty;
        public string UpdatedBy { get; set; } = string.Empty;
        public string UpdatedDate { get; set; } = string.Empty;
    }

    public class CompanyServiceScopeDocumentFileDto
    {
        public int ID { get; set; }
        public string? StartPeriod { get; set; } = string.Empty;
        public string? EndPeriod { get; set; } = string.Empty;
        public string? AdditionalInformation { get; set; } = string.Empty;
        public string? Notes { get; set; } = string.Empty;
        public string? FileName { get; set; } = string.Empty;
        public string? OriginalFileName { get; set; } = string.Empty;
        public string? FilePath { get; set; } = string.Empty;
    }
}
