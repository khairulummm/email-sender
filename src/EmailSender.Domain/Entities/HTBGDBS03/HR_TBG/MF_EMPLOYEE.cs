using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataIntegration.Domain.Entities.HTBGDBS03.HR_TBG
{
    [Table("MF_EMPLOYEE", Schema = "tbg")]
    public class MF_EMPLOYEE
    {
        [Key]
        [MaxLength(50)]
        public string Employ_Id { get; set; } = null!;

        [MaxLength(50)]
        public string? Employ_Id_TBGSYS { get; set; }

        [MaxLength(50)]
        public string? Badge_Id { get; set; }

        public string? Name { get; set; }
        public string? Nick_Name { get; set; }

        public decimal? Gender_code { get; set; }

        public string? Place_of_Birth { get; set; }

        public DateTime? Date_of_Birth { get; set; }

        public decimal? Religion_code { get; set; }

        public decimal? Marital_Status_code { get; set; }

        public decimal? Blood_Type_code { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? Zip_code { get; set; }

        public string? Phone { get; set; }

        public string? HP_No { get; set; }

        public string? Email { get; set; }

        public string? ID_No { get; set; }

        public string? ID_Address { get; set; }

        public string? ID_City { get; set; }

        public string? ID_Zip_code { get; set; }

        public string? Certificated_No { get; set; }

        public DateTime? Join_Date { get; set; }

        public DateTime? Effective_Date { get; set; }

        public string? Resign_status { get; set; }

        public DateTime? Resign_Date { get; set; }

        public decimal? Job_status_code { get; set; }

        public decimal? Employee_status_code { get; set; }

        public DateTime? Expired_status { get; set; }

        public decimal? Contract_Extend { get; set; }

        public string? Scheduling_Shift { get; set; }

        public string? Shift { get; set; }

        public decimal? Tax_Status_code { get; set; }

        public string? Tax_calculation { get; set; }

        public string? NPWP_No { get; set; }

        public DateTime? NPWP_Date { get; set; }

        public string? Jamsostek_No { get; set; }

        public DateTime? Jamsostek_Date { get; set; }

        public string? DPLK_No { get; set; }

        public DateTime? DPLK_Date { get; set; }

        public decimal? Emp_Contribution { get; set; }

        public decimal? Company_code { get; set; }

        [MaxLength(50)]
        public string? Branch_code { get; set; }

        [MaxLength(50)]
        public string? Directorate_code { get; set; }

        [MaxLength(50)]
        public string? Division_code { get; set; }

        [MaxLength(50)]
        public string? Department_code { get; set; }

        [MaxLength(50)]
        public string? Section_code { get; set; }

        [MaxLength(50)]
        public string? Job_Title_code { get; set; }

        public decimal? Grade_code { get; set; }

        public string? Sub_Grade { get; set; }

        [MaxLength(50)]
        public string? Report_Code { get; set; }

        public string? Payment_type { get; set; }

        [MaxLength(50)]
        public string? Bank_code { get; set; }

        public string? Account_No { get; set; }

        public string? Account_name { get; set; }

        public DateTime? Audit_Date { get; set; }

        [MaxLength(50)]
        public string? Audit_User { get; set; }

        [MaxLength(50)]
        public string? PositionCode { get; set; }

        [MaxLength(100)]
        public string? PositionName { get; set; }

        [MaxLength(50)]
        public string? DepartmentCode { get; set; }

        [MaxLength(100)]
        public string? DepartmentName { get; set; }

        [MaxLength(50)]
        public string? DivisionCode { get; set; }

        [MaxLength(100)]
        public string? DivisionName { get; set; }

        [MaxLength(50)]
        public string? DirectorateCode { get; set; }

        [MaxLength(100)]
        public string? DirectorateName { get; set; }

        [MaxLength(50)]
        public string? Employ_Id_HCIS { get; set; }

        [MaxLength(100)]
        public string? Level_Position { get; set; }

        [MaxLength(2)]
        public string? LevelPositionID { get; set; }

        // Foreign key ke MstHCSVendOutsource
        public int? IDVendOS { get; set; }

        [MaxLength(20)]
        public string? JobTitleID { get; set; }

        [MaxLength(150)]
        public string? JobTitleName { get; set; }

        [MaxLength(2)]
        public string? WorkLocation { get; set; }

        [MaxLength(50)]
        public string? MovementType { get; set; }

        public DateTime? Married_date { get; set; }

        [MaxLength(20)]
        public string? JobTitleShadowID { get; set; }

        // Navigasi opsional (jika ingin include entitas terkait)
        // public MstHCSVendOutsource? VendorOutsource { get; set; }
    }
}
