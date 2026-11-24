using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Application.DTOs.VendorRegistration
{
    public class Document
    {
        public int ID { get; set; }

        public int? IdDocumentVenreg { get; set; }

        public string? DocumentName { get; set; }

        public string? DocumentType { get; set; }

        public string? AdditionalInformation { get; set; }

        public bool? IsActive { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string? FilePath { get; set; }

        public string? DocumentCategory { get; set; }

        public string? QhseDocumentCategory { get; set; }

        public bool? IsUnique { get; set; }
    }
}
