using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Domain.Models.ViewModels
{
    public class CallerInfo
    {
        public string Namespace { get; set; }
        public string ServiceName { get; set; }
        public string MethodName { get; set; }
    }
}
