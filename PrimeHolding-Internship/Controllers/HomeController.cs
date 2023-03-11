using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

using PrimeHolding_Internship.Models;
using PrimeHolding_Internship.Core.Contracts;

namespace PrimeHolding_Internship.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeService employeeService;

        public HomeController(IEmployeeService _employeeService)
        {
            employeeService = _employeeService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await employeeService.TopFiveEmployees();

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}