using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Application.DTOs.VendorRegistration
{
    public class CompanyAddressDto
    {
        public int ID { get; set; }
        public IdNameDto Country { get; set; } = new IdNameDto();
        public IdNameDto Province { get; set; } = new IdNameDto();
        public IdNameDto City { get; set; } = new IdNameDto();
        public IdNameDto Urban { get; set; } = new IdNameDto();
        public IdNameDto District { get; set; } = new IdNameDto();
        public IdNameDto PostalCode { get; set; } = new IdNameDto();
        public string FullAddress { get; set; } = string.Empty;
        public string CoresspondenceAddress { get; set; } = string.Empty;
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public string CreatedDate { get; set; } = string.Empty;
        public string UpdatedBy { get; set; } = string.Empty;
        public string UpdatedDate { get; set; } = string.Empty;
    }
}
