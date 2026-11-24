using DataIntegration.Domain.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Domain.Models.ViewModels.BUS.IKR
{
    public class dtPostIKRGeneratePurchase : BaseClass
    {
        public dtPostIKRGeneratePurchase()
        {
            ErrorType = 0;
            ErrorMessage = string.Empty;
        }

        public dtPostIKRGeneratePurchase(int errorType, string? errorMessage)
        {
            ErrorType = errorType;
            ErrorMessage = errorMessage;
        }

        public int? FTTHIKRGenerateID { get; set; }
        public int? WOTypeID { get; set; }
        public string RequestBy { get; set; }
        public string ReviewBy { get; set; }
        public string ApproveBy { get; set; }
        public string ConfirmBy { get; set; }
        public string CreateBy { get; set; }
    }
}
