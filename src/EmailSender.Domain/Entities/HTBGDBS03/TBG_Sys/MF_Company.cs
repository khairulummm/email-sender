using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Domain.Entities.HTBGDBS03.TBG_Sys
{
    [Table("MF_Company", Schema = "tbg")]
    public class MF_Company
    {
        [Key]
        [Column("company_id", TypeName = "char(3)")]
        [Required]
        public string CompanyId { get; set; } = string.Empty;

        [Column("company_cd", TypeName = "char(2)")]
        public string? CompanyCd { get; set; }

        [Column("company_id_finance", TypeName = "char(4)")]
        public string? CompanyIdFinance { get; set; }

        [Column("company")]
        [MaxLength(35)]
        public string? Company { get; set; }

        [Column("address")]
        [MaxLength(255)]
        public string? Address { get; set; }

        [Column("address1")]
        [MaxLength(255)]
        public string? Address1 { get; set; }

        [Column("address2")]
        [MaxLength(255)]
        public string? Address2 { get; set; }

        [Column("zip_code")]
        [MaxLength(255)]
        public string? ZipCode { get; set; }

        [Column("telp")]
        [MaxLength(50)]
        public string? Telp { get; set; }

        [Column("fax")]
        [MaxLength(50)]
        public string? Fax { get; set; }

        [Column("bank_name")]
        [MaxLength(100)]
        public string? BankName { get; set; }

        [Column("acc_no")]
        [MaxLength(100)]
        public string? AccNo { get; set; }

        [Column("npwp")]
        [MaxLength(100)]
        public string? NPWP { get; set; }

        [Column("manager")]
        [MaxLength(100)]
        public string? Manager { get; set; }

        [Column("company_ax", TypeName = "char(4)")]
        public string? CompanyAX { get; set; }

        [Column("audit_user")]
        [MaxLength(12)]
        public string? AuditUser { get; set; }

        [Column("audit_date")]
        public DateTime? AuditDate { get; set; }

        [Column("CompanyIDAX", TypeName = "char(4)")]
        public string? CompanyIDAX { get; set; }

        [Column("direktur")]
        [MaxLength(200)]
        public string? Direktur { get; set; }

        [Column("jabatan")]
        [MaxLength(100)]
        public string? Jabatan { get; set; }
    }
}
