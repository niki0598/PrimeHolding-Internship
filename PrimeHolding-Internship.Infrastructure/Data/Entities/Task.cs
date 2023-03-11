using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using PrimeHolding_Internship.Common;

namespace PrimeHolding_Internship.Infrastructure.Data.Entities
{
    public class Task
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.TaskTitleMaxLength)]
        public string Title { get; set; } = null!;

        [MaxLength(GlobalConstants.TaskDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [ForeignKey(nameof(Employee))]
        public int? EmployeeId { get; set; }
        public virtual Employee? Employee { get; set; } = null!;

        public DateTime DueDate { get; set; }

        public DateTime? DateCompleted { get; set; } = null;

        public bool IsCompleted { get; set; } = false;
    }
}