using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Application.DTOs.VendorRegistration
{
    public class CompanyProfileWrapperDto
    {
        public CompanyProfileDto CompanyProfile { get; set; } = new CompanyProfileDto();
    }

    public class CompanyProfileDto
    {
        public CompanyDetailDto Company { get; set; } = new CompanyDetailDto();
        public List<CompanyServiceScopeDto> ServiceScopes { get; set; } = new List<CompanyServiceScopeDto>();
        public CompanyEmailGroupDto Emails { get; set; } = new CompanyEmailGroupDto();
        public CompanyManagementDto Management { get; set; } = new CompanyManagementDto();
        public List<CompanyFinancialDto> FinancialInformations { get; set; } = new List<CompanyFinancialDto>();
        public List<CompanyBranchOfficesDto> BranchOffices { get; set; } = new List<CompanyBranchOfficesDto>();
        public List<CompanyContactPersonDto> ContactPersons { get; set; } = new List<CompanyContactPersonDto>();
        public ExperiencesDto Experience { get; set; } = new ExperiencesDto();
        public List<CompanyFinancialReportDto> FinancialReports { get; set; } = new List<CompanyFinancialReportDto>();
        public CompanyAddressDto Address { get; set; } = new CompanyAddressDto();
        public List<CompanyDocumentDto> Document { get; set; } = new List<CompanyDocumentDto>();
        public List<CompanyServiceScopeDocumentDto> ServiceScopeDocuments { get; set; } = new List<CompanyServiceScopeDocumentDto>();
        public List<CompanyServiceScopeRegionCapacityDto> ServiceScopeRegionCapacities { get; set; } = new List<CompanyServiceScopeRegionCapacityDto>();
        public List<CompanyQHSEDocumentStatementLetterDto> QHSEDocumentStatementLetters { get; set; } = new List<CompanyQHSEDocumentStatementLetterDto>();
        public List<CompanyQHSEDocumentPersonalDto> QHSEPersonalDocuments { get; set; } = new List<CompanyQHSEDocumentPersonalDto>();
        public List<CompanyQHSEDocumentCorporateDto> QHSECorporateDocuments { get; set; } = new List<CompanyQHSEDocumentCorporateDto>();
        public CompanyQualificationDto CompanyQualification { get; set; } = new CompanyQualificationDto();
    }
}
