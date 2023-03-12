namespace PrimeHolding_Internship.Core.Models.Tasks
{
    public class TaskActiveViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string? Employee { get; set; }

        public DateTime DueDate { get; set; }
    }
}