using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DWBooking.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DWBooking.Pages.Admin.Employee
{
    public class AddEmployeeModel : PageModel
    {
        private EmployeeService employeeService;
        private List<Model.Employee> employees;

        [BindProperty]
        public Model.Employee Employee { get; set; }

        public AddEmployeeModel(EmployeeService iS)
        {
            employeeService = iS;
            employees = MockData.MockEmployees.GetMockEmployees();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            employeeService.AddEmployee(Employee);
            return RedirectToPage("GetAllEmployees");
        }
    }
}
