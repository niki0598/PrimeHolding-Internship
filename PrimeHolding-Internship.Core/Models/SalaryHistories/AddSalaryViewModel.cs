using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static PrimeHolding_Internship.Common.GlobalConstants;
using PrimeHolding_Internship.Infrastructure.Data.Entities;

namespace PrimeHolding_Internship.Core.Models.SalaryHistories
{
    public class AddSalaryViewModel
    {
        public int Id { get; set; }

        [Required]
        [Range(1.00, 99999999.00, ErrorMessage = "Salary must be greater than 0")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Salary { get; set; }

        public int EmployeeId { get; set; }

        [Required]
        [StringLength(SalaryChangeDateReasonMaxLength), MinLength(SalaryChangeDateReasonMinLength)]
        public string Reason { get; set; } = null!;

        public virtual IEnumerable<Employee> Employees { get; set; }
            = new List<Employee>();
    }
}