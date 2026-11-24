using DataIntegration.Domain.Entities.TBIGSYSDB01.TBGFTTH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Domain.Models.ViewModels.BUS.IKR
{
    public class vmIKRGeneratePurchase
    {
        public trxBUSFTTHIKRGeneratePurchase GeneratePurchase { get; set; }
        public int ID { get; set; }
        public int ResidenceID { get; set; }
        public bool IsDone { get; set; }
    }
}
