namespace PrimeHolding_Internship.Core.Models.SalaryHistories
{
    public class SalaryHistoryViewModel
    {
        public int Id { get; set; }

        public decimal Salary { get; set; }

        public string Employee { get; set; } = null!;

        public DateTime SalaryChangeDate { get; set; }

        public string Reason { get; set; } = null!;
    }
}