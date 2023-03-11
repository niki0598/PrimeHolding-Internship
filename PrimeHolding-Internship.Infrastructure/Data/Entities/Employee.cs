using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using PrimeHolding_Internship.Common;

namespace PrimeHolding_Internship.Infrastructure.Data.Entities
{
    public class Employee
    {
        public Employee()
        {
            Tasks = new List<Task>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.EmployeeFullNameMaxLength)]
        public string FullName { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [MaxLength(GlobalConstants.EmployeePhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = null!;

        public DateTime? BirthDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Salary { get; set; }

        public int TasksCompleted { get; set; } = 0;

        public virtual ICollection<Task> Tasks { get; set; }
            = new List<Task>();
    }
}