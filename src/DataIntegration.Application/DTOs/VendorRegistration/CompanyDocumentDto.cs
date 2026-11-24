using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Application.DTOs.VendorRegistration
{
    public class CompanyDocumentDto
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<IdNameDto> CoreBusiness { get; set; } = new List<IdNameDto>();
        //public List<CompanyDocumentFileDto> File { get; set; } = new List<CompanyDocumentFileDto>();
    }

    public class CompanyDocumentFileDto
    {
        public int ID { get; set; }
        public string Start { get; set; } = string.Empty;
        public string End { get; set; } = string.Empty;
    }
}
