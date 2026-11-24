using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Application.DTOs.VendorRegistration
{
    public class CompanyAddress
    {
        public int ID { get; set; }
        public int? CompanyID { get; set; }
        public int? CountryID { get; set; }
        public int? ProvinceID { get; set; }
        public int? CityID { get; set; }
        public int? UrbanID { get; set; }
        public int? DistrictID { get; set; }
        public int? PostalCodeID { get; set; }
        public string? FullAddress { get; set; }
        public string? CoresspondenceAddress { get; set; }
        public bool? IsActive { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
