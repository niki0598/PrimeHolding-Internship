using PrimeHolding_Internship.Core.Models.SalaryHistories;

namespace PrimeHolding_Internship.Core.Contracts
{
    public interface ISalaryHistory
    {
        Task SalaryChangeAsync(AddSalaryViewModel model, int employeeId);

        Task<IEnumerable<SalaryHistoryViewModel>> GetAllAsync();
    }
}
