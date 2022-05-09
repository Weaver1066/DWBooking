using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DWBooking.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DWBooking.Pages.Admin.Employee
{
    public class GetAllEmployeesModel : PageModel
    {
        private EmployeeService employeeService;

        public List<Model.Employee> Employees { get; private set; }

        public GetAllEmployeesModel(EmployeeService employeeService) //Dependency Injection
        {
            this.employeeService = employeeService;
        }
        public IActionResult OnGet()
        {
            Employees = employeeService.GetEmployees().ToList();
            //Events.Sort();
            return Page();
        }
    }
}
