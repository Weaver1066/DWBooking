using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DWBooking.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DWBooking.Pages.Bruger.Login
{
    public class LogInPageModel : PageModel
    {
        private UserService _userService;
        private EmployeeService _employeeService;

        public LogInPageModel(UserService userService, EmployeeService employeeService)
        {
            _userService = userService;
            _employeeService = employeeService;
        }

        [BindProperty]
        public string UserName { get; set; }

        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; }

        public string Message { get; set; }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            List<Model.Employee> employees = _employeeService.GetEmployeesAndUsers().Result.ToList();
            foreach (Model.Employee employee in employees)
            {
                if(employee.User != null)
                if (UserName == employee.User.Username)
                {
                    var passwordHasher = new PasswordHasher<string>();
                    //if (passwordHasher.VerifyHashedPassword(null, employee.User.Password, Password) == PasswordVerificationResult.Success)
                    //{
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, UserName)
                        };

                        if (employee.Role == 1) claims.Add(new Claim(ClaimTypes.Role, "admin"));
                        else if (employee.Role == 2) claims.Add(new Claim(ClaimTypes.Role, "rådgiver"));

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                        return RedirectToPage("/Admin/Counceling/GetAllCounceling");
                    //}
                }
            }

            Message = "Invalid attempt";
            return Page();
        }
    }
}

