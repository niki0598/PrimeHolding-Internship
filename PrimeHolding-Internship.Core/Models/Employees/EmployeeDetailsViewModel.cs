using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static PrimeHolding_Internship.Common.GlobalConstants;

namespace PrimeHolding_Internship.Core.Models.Employees
{
    public class EmployeeDetailsViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(EmployeeFullNameMaxLength, MinimumLength = EmployeeFullNameMinLength)]
        public string FullName { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [StringLength(EmployeePhoneNumberMaxLength, MinimumLength = EmployeePhoneNumberMinLength)]
        public string PhoneNumber { get; set; } = null!;

        public string? BirthDate { get; set; }
        
        public int TasksCompleted { get; set; }

        [Required]
        [Range(1.00, 99999999.00, ErrorMessage = "Salary must be greater than 0")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Salary { get; set; }
    }
}
