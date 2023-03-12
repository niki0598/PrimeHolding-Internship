using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimeHolding_Internship.Infrastructure.Data.Entities
{
    public class SalaryHistory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Salary { get; set; }

        [ForeignKey(nameof(Employee))]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; } = null!;

        public DateTime SalaryChangeDate { get; set; }

        [Required] 
        public string Reason { get; set; } = null!;
    }
}
