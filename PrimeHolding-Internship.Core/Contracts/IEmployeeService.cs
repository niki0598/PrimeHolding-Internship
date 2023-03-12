using Task = System.Threading.Tasks.Task;

using PrimeHolding_Internship.Core.Models.Employees;
using PrimeHolding_Internship.Infrastructure.Data.Entities;

namespace PrimeHolding_Internship.Core.Contracts
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDetailsViewModel>> GetAllAsync();

        Task<IEnumerable<Employee>> GetAllToListAsync();

        Task AddEmployeeAsync(EmployeeDetailsViewModel model);

        Task<Employee> GetByIdAsync(int employeeId);

        Task EditEmployeeAsync(int employeeId, EmployeeEditViewModel model);

        Task DeleteEmployeeAsync(int employeeId);

        Task<IEnumerable<EmployeeDetailsViewModel>> TopFiveEmployees();
    }
}
