using System.ComponentModel.DataAnnotations;

using static PrimeHolding_Internship.Common.GlobalConstants;

namespace PrimeHolding_Internship.Core.Models.Employees
{
    public class EmployeeEditViewModel
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
    }
}
