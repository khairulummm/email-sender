using System.Collections.Generic;

namespace DataIntegration.Application.DTOs.VendorRegistration
{
    public class ExperiencesDto
    {
        public int ID { get; set; }
        public int? NumberOfPermanentEmployee { get; set; }
        public bool? IsHaveBranchOffice { get; set; }

        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public string CreatedDate { get; set; } = string.Empty;
        public string UpdatedBy { get; set; } = string.Empty;
        public string UpdatedDate { get; set; } = string.Empty;
    }
}