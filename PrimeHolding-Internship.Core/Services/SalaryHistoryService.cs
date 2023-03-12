using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

using PrimeHolding_Internship.Core.Contracts;
using PrimeHolding_Internship.Core.Models.SalaryHistories;
using PrimeHolding_Internship.Infrastructure.Data;
using PrimeHolding_Internship.Infrastructure.Data.Entities;

namespace PrimeHolding_Internship.Core.Services
{
    public class SalaryHistoryService : ISalaryHistory
    {
        private readonly AssignmentDbContext context;

        public SalaryHistoryService(AssignmentDbContext _context)
        {
            context = _context;
        }

        public async Task SalaryChangeAsync(AddSalaryViewModel model, int id)
        {
            var employee = await context.Employees
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();

            if (employee != null)
            {
                var salaryChange = new SalaryHistory
                {
                    Id = model.Id,
                    EmployeeId = model.EmployeeId,
                    Salary = model.Salary,
                    Reason = model.Reason,
                    SalaryChangeDate = DateTime.Now
                };

                employee.Salary = model.Salary;

            context.Employees.Update(employee);
            await context.SalariesHistory.AddAsync(salaryChange);
            await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<SalaryHistoryViewModel>> GetAllAsync()
        {
            var salariesHistory = await context.SalariesHistory
                .Include(e => e.Employee)
                .ToListAsync();

            return salariesHistory
                .Select(s => new SalaryHistoryViewModel
                {
                    Id = s.Id,
                    Salary = s.Salary,
                    Employee = s.Employee.FullName,
                    SalaryChangeDate = s.SalaryChangeDate,
                    Reason = s.Reason,
                });
        }
    }
}