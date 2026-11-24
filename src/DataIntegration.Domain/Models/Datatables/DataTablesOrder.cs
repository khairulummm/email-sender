using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Domain.Models.Datatables
{
    public class DataTablesOrder
    {
        // Index kolom yang diurutkan
        public int Column { get; set; }
        // Arah sorting (asc/desc)
        public string Dir { get; set; } = "asc";
    }
}
