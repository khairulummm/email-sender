using DataIntegration.Domain.Models.Datatables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Domain.Models.ViewModels
{
    public class VmmstInputTargetStatus : DataTablesRequest
    {
        public string? Status { get; set; }

        public string? Description { get; set; }
    }
}
