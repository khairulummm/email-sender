using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Application.DTOs.VendorRegistration
{
    public class CompanyFinancialReport
    {
        public int ID { get; set; }

        public int CompanyID { get; set; }

        public string? ReportYear { get; set; }

        public int? FinancialReportTypeID { get; set; }

        public decimal? CurrentAsset { get; set; }

        public decimal? CurrentLiabilities { get; set; }

        public decimal? Inventories { get; set; }

        public decimal? TotalLiabilities { get; set; }

        public decimal? TotalEquity { get; set; }

        public decimal? OperationIncome { get; set; }

        public decimal? Depreciation { get; set; }

        public decimal? NetSalesPerAnnum { get; set; }

        public decimal? AverageOfAccountReceivable { get; set; }

        public bool? IsActive { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
