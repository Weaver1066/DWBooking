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
        [BindProperty] public int Role { get; set; }
        private EmployeeService employeeService;
        private List<Model.Employee> employees;


        [BindProperty]
        public Model.Employee Employee { get; set; }

        public AddEmployeeModel(EmployeeService iS)
        {
            employeeService = iS;
            //employees = MockData.MockEmployees.GetMockEmployees();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPostAddEmployee()
        {
            Employee.Role = Convert.ToInt32(Request.Form[("roleSelect")]);
            if (!ModelState.IsValid)
            {
                return Page();
            }
            employeeService.AddEmployee(Employee);
            return RedirectToPage("GetAllEmployees");
        }

        public IActionResult OnPostSelectRole()
        {
            Role = Convert.ToInt32(Request.Form[("roleSelect")]);

            return Page();
        }
    }
}
