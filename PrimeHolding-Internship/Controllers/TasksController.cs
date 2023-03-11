using Microsoft.AspNetCore.Mvc;

using PrimeHolding_Internship.Core.Contracts;
using PrimeHolding_Internship.Core.Models.Tasks;

namespace PrimeHolding_Internship.Controllers
{
    public class TasksController : Controller
    {
        private readonly ITaskService taskService;
        private readonly IEmployeeService employeeService;

        public TasksController(ITaskService _taskService,
            IEmployeeService _employeeService)
        {
            taskService = _taskService;
            employeeService = _employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> AllTasks()
        {
            var model = await taskService.GetAllAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ActiveTasks()
        {
            var model = await taskService.GetActiveAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddTask()
        {
            var model = new TaskDetailsViewModel
            {
                Employees = await employeeService.GetAllToListAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddTask(TaskDetailsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await taskService.AddTaskAsync(model);

                return RedirectToAction(nameof(AllTasks));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");

                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditTask(int id)
        {
            var task = await taskService.GetByIdAsync(id);

            var model = new TaskDetailsViewModel
            {
                Title = task.Title,
                Description = task.Description,
                Employees = await employeeService.GetAllToListAsync(),
                EmployeeId = task.EmployeeId,
                DueDate = task.DueDate,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditTask(TaskDetailsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await taskService.EditTaskAsync(model.Id, model);

                return RedirectToAction(nameof(ActiveTasks));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");

                return View(model);
            }
        }

        public async Task<IActionResult> DeleteTask(int id)
        {
            await taskService.DeleteTaskAsync(id);

            return RedirectToAction(nameof(AllTasks));
        }

        public async Task<IActionResult> CompleteTask(int id)
        {
            await taskService.CompleteTask(id);

            return RedirectToAction(nameof(ActiveTasks));
        }
    }
}
