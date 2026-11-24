using System.ComponentModel.DataAnnotations;

namespace DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys
{
    public class uspGetFirstLastName
    {
        [Key]
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public decimal GenderCode { get; set; }
    }
}
