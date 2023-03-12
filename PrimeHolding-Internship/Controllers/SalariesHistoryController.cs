using Microsoft.AspNetCore.Mvc;

using PrimeHolding_Internship.Core.Contracts;
using PrimeHolding_Internship.Core.Models.SalaryHistories;

namespace PrimeHolding_Internship.Controllers
{
    public class SalariesHistoryController : Controller
    {
        private readonly ISalaryHistory salaryHistory;
        private readonly IEmployeeService employeeService;

        public SalariesHistoryController(ISalaryHistory _salaryHistory,
            IEmployeeService _employeeService)
        {
            salaryHistory = _salaryHistory;
            employeeService = _employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> SalaryChange()
        {
            var model = new AddSalaryViewModel
            {
                Employees = await employeeService.GetAllToListAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SalaryChange(AddSalaryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await salaryHistory.SalaryChangeAsync(model, model.EmployeeId);

                return RedirectToAction(nameof(SalariesHistory));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");

                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> SalariesHistory()
        {
            var model = await salaryHistory.GetAllAsync();

            return View(model);
        }
    }
}
