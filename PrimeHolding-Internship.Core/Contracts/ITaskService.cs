using Task = System.Threading.Tasks.Task;
using TaskEntity = PrimeHolding_Internship.Infrastructure.Data.Entities.Task;

using PrimeHolding_Internship.Core.Models.Tasks;

namespace PrimeHolding_Internship.Core.Contracts
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskDetailsViewModel>> GetAllAsync();

        Task<IEnumerable<TaskDetailsViewModel>> GetActiveAsync();

        Task AddTaskAsync(TaskDetailsViewModel model);

        Task<TaskEntity> GetByIdAsync(int taskId);

        Task EditTaskAsync(int taskId, TaskDetailsViewModel model);

        Task DeleteTaskAsync(int taskId);

        Task CompleteTask(int taskId);
    }
}
