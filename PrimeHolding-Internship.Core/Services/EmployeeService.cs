using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

using PrimeHolding_Internship.Core.Contracts;
using PrimeHolding_Internship.Core.Models.Employees;
using PrimeHolding_Internship.Infrastructure.Data;
using PrimeHolding_Internship.Infrastructure.Data.Entities;

namespace PrimeHolding_Internship.Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AssignmentDbContext context;

        public EmployeeService(AssignmentDbContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<EmployeeDetailsViewModel>> GetAllAsync()
        {
            var entities = await context.Employees
                .ToListAsync();

            return entities
                .Select(e => new EmployeeDetailsViewModel
                {
                    Id = e.Id,
                    FullName = e.FullName,
                    Email = e.Email,
                    PhoneNumber = e.PhoneNumber,
                    BirthDate = e.BirthDate?.Date.ToShortDateString(),
                    Salary = e.Salary
                });
        }

        public async Task<IEnumerable<Employee>> GetAllToListAsync()
        {
            return await context.Employees
                .ToListAsync();
        }

        public async Task AddEmployeeAsync(EmployeeDetailsViewModel model)
        {
            var employee = new Employee
            {
                Id = model.Id,
                FullName = model.FullName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                BirthDate = DateTime.Parse(model.BirthDate!),
                TasksCompleted = 0,
                Salary = model.Salary
            };

            await context.Employees.AddAsync(employee);
            await context.SaveChangesAsync();
        }

        public async Task<Employee> GetByIdAsync(int employeeId)
        {
            return await context.Employees
                .Where(e => e.Id == employeeId)
                .FirstAsync();
        }

        public async Task EditEmployeeAsync(int employeeId, EmployeeDetailsViewModel model)
        {
            var employee = await context.Employees
                .Where(e => e.Id == employeeId)
                .FirstOrDefaultAsync();

            if (employee != null)
            {
                employee.FullName = model.FullName;
                employee.Email = model.Email;
                employee.PhoneNumber = model.PhoneNumber;
                employee.BirthDate = DateTime.Parse(model.BirthDate!);
                employee.Salary = model.Salary;
            }

            await context.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(int employeeId)
        {
            var employee = await context.Employees
                .Where(e => e.Id == employeeId)
                .FirstOrDefaultAsync();

            if (employee != null)
            {
                var tasks = await context.Tasks
                    .Where(t => t.EmployeeId == employeeId)
                    .Include(e => e.Employee)
                    .ToListAsync();

                foreach (var task in tasks)
                {
                    task.EmployeeId = null;
                    context.Entry(task).State = EntityState.Modified;
                }

                context.Employees.Remove(employee);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<EmployeeDetailsViewModel>> TopFiveEmployees()
        {
            var startDate = DateTime.Today.AddMonths(-1);
            var endDate = DateTime.Now;

            var employees = await context.Employees
                .Include(t => t.Tasks)
                .Where(e => e.Tasks.Any(t => t.DateCompleted >= startDate && t.DateCompleted <= endDate))
                .ToListAsync();

            var topFiveEmployees = employees
                .OrderByDescending(e => e.Tasks.Count(t => t.DateCompleted >= startDate && t.DateCompleted <= endDate))
                .Select(e => new EmployeeDetailsViewModel()
                {
                    FullName = e.FullName,
                    Email = e.Email,
                    PhoneNumber = e.PhoneNumber,
                    BirthDate = e.BirthDate?.ToShortDateString(),
                    TasksCompleted = e.TasksCompleted,
                    Salary = e.Salary
                })
                .Take(5)
                .ToList();

            return topFiveEmployees;
        }
    }
}