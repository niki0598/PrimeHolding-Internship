using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;
using TaskEntity = PrimeHolding_Internship.Infrastructure.Data.Entities.Task;

using PrimeHolding_Internship.Core.Contracts;
using PrimeHolding_Internship.Core.Models.Tasks;
using PrimeHolding_Internship.Infrastructure.Data;

namespace PrimeHolding_Internship.Core.Services
{
    public class TaskService : ITaskService
    {
        private readonly AssignmentDbContext context;

        public TaskService(AssignmentDbContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<TaskDetailsViewModel>> GetAllAsync()
        {
            var tasks = await context.Tasks
                .Include(e => e.Employee)
                .ToListAsync();

            return tasks
                .Select(t => new TaskDetailsViewModel()
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    Employee = t.Employee?.FullName,
                    IsCompleted = t.IsCompleted,
                    DateCompleted = t.DateCompleted,
                    DueDate = t.DueDate
                });
        }

        public async Task<IEnumerable<TaskDetailsViewModel>> GetActiveAsync()
        {
            var tasks = await context.Tasks
                .Include(e => e.Employee)
                .Where(t => t.DateCompleted == null)
                .ToListAsync();

            return tasks
                .Select(t => new TaskDetailsViewModel()
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    Employee = t.Employee?.FullName,
                    DueDate = t.DueDate
                });
        }

        public async Task AddTaskAsync(TaskDetailsViewModel model)
        {
            var task = new TaskEntity
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                EmployeeId = model.EmployeeId,
                DueDate = model.DueDate
            };

            await context.Tasks.AddAsync(task);
            await context.SaveChangesAsync();
        }

        public async Task<TaskEntity> GetByIdAsync(int taskId)
        {
            return await context.Tasks
                .Where(t => t.Id == taskId)
                .FirstAsync();
        }

        public async Task EditTaskAsync(int taskId, TaskDetailsViewModel model)
        {
            var task = await context.Tasks
                .Where(t => t.Id == taskId)
                .FirstOrDefaultAsync();

            if (task != null)
            {
                task.Id = model.Id;
                task.Title = model.Title;
                task.Description = model.Description;
                task.EmployeeId = model.EmployeeId;
                task.DueDate = model.DueDate;
            }

            await context.SaveChangesAsync();
        }

        public async Task DeleteTaskAsync(int taskId)
        {
            var task = await context.Tasks
                .Where(t => t.Id == taskId)
                .FirstOrDefaultAsync();

            if (task != null)
            {
                context.Tasks.Remove(task);
                await context.SaveChangesAsync();
            }
        }

        public async Task CompleteTask( int taskId)
        {
            var task = await context.Tasks
                .Where(t => t.Id == taskId)
                .FirstOrDefaultAsync();

            var employee = await context.Employees
                .Include(t => t.Tasks)
                .Where(e => e.Tasks.Any(t => t.Id == taskId))
                .FirstOrDefaultAsync();

            if (employee != null && task != null)
            {
                task.IsCompleted = true;
                task.DateCompleted = DateTime.Now;

                employee.TasksCompleted++;
            }

            await context.SaveChangesAsync();
        }
    }
}
