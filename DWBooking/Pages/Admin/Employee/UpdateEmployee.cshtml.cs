using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DWBooking.Model;
using DWBooking.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DWBooking.Pages.Admin.Employee
{
    public class UpdateEmployeeModel : PageModel
    {
        private EmployeeService employeeService;
        [BindProperty] public Model.Employee Employee{ get; set; }

        public UpdateEmployeeModel(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public IActionResult OnGet(int id)
        {
            Employee = employeeService.GetEmployee(id);
            return Page();
        }

        public async Task<IActionResult> OnPost(int id)
        {
            Employee.EmployeeID = id;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await employeeService.UpdateEmployeeAsync(Employee);
            return RedirectToPage("GetAllEmployees");
        }
    }
}
