using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Domain.Models.Datatables
{
    public class DataTablesSearch
    {
        public string Value { get; set; } = string.Empty;
        public bool Regex { get; set; }
    }
}
