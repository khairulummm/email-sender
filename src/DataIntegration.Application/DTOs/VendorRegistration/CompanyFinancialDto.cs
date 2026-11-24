using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Application.DTOs.VendorRegistration
{
    public class CompanyFinancialDto
    {
        public int ID { get; set; }
        public IdNameDto? PaymentRecipient { get; set; }
        public IdNameDto? Citizen { get; set; }
        public IdNameDto? BankAccount { get; set; }
        public IdNameDto? Currency { get; set; }

        public string AccountName { get; set; } = string.Empty;
        public string RecipientAddress { get; set; } = string.Empty;
        public string AccountNumber { get; set; } = string.Empty;
        public string BankBranch { get; set; } = string.Empty;
        public string BankAddress { get; set; } = string.Empty;
        public string AdditionalCurrencyInformation { get; set; } = string.Empty;

        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public string CreatedDate { get; set; } = string.Empty;
        public string UpdatedBy { get; set; } = string.Empty;
        public string UpdatedDate { get; set; } = string.Empty;
    }
}
