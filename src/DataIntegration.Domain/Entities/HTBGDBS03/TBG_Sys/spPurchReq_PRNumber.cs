using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Domain.Entities.HTBGDBS03.TBG_Sys
{
    /// <summary>
    /// Represents the result returned by stored procedure [TBG_Sys].[tbg].[spPurchReq_PRNumber].
    /// </summary>
    public class spPurchReq_PRNumber
    {
        /// <summary>
        /// Returned PR number (for @f_type = 'PR' or part of 'PR PV').
        /// </summary>
        [Key]
        [Column("PRNumber")]
        public string? PRNumber { get; set; }

        /// <summary>
        /// Returned Request number (for @f_type = 'Request', 'PR PV', or 'R PV').
        /// </summary>
        [Column("RequestNumber")]
        public string? RequestNumber { get; set; }

        /// <summary>
        /// Returned STIP counter (for @f_type = 'STIP').
        /// </summary>
        [Column("NextCounter")]
        public int? NextCounter { get; set; }
    }
}
