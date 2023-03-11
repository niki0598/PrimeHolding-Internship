using System.ComponentModel.DataAnnotations;

using PrimeHolding_Internship.Infrastructure.Data.Entities;
using static PrimeHolding_Internship.Common.GlobalConstants;

namespace PrimeHolding_Internship.Core.Models.Tasks
{
    public class TaskDetailsViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(TaskTitleMaxLength, MinimumLength = TaskTitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(TaskDescriptionMaxLength, MinimumLength = TaskDescriptionMinLength)]
        public string Description { get; set; } = null!;

        public int? EmployeeId { get; set; }

        public string? Employee { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime? DateCompleted { get; set; } = null;

        public bool IsCompleted { get; set; }

        public virtual IEnumerable<Employee> Employees { get; set; }
            = new List<Employee>();
    }
}