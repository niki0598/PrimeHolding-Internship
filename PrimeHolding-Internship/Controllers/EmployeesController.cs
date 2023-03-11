using Microsoft.AspNetCore.Mvc;

using PrimeHolding_Internship.Core.Contracts;
using PrimeHolding_Internship.Core.Models.Employees;

namespace PrimeHolding_Internship.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService employeeService;

        public EmployeesController(IEmployeeService _employeeService)
        {
            employeeService = _employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> AllEmployees()
        {
            var model = await employeeService.GetAllAsync();

            return View(model);
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            var model = new EmployeeDetailsViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeDetailsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await employeeService.AddEmployeeAsync(model);

                return RedirectToAction(nameof(AllEmployees));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");

                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditEmployee(int id)
        {
            var employee = await employeeService.GetByIdAsync(id);

            var model = new EmployeeDetailsViewModel()
            {
                FullName = employee.FullName,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                BirthDate = employee.BirthDate?.ToShortDateString(),
                Salary = employee.Salary
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditEmployee(EmployeeDetailsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await employeeService.EditEmployeeAsync(model.Id, model);

                return RedirectToAction(nameof(AllEmployees));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");

                return View(model);
            }
        }

       
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await employeeService.DeleteEmployeeAsync(id);

            return RedirectToAction(nameof(AllEmployees));
        }
    }
}
