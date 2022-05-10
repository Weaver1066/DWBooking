using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DWBooking.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace DWBooking.Pages.Admin.Clients
{
    public class AddClientModel : PageModel
    {
        private CouncelingService councelingService;
        private ClientService clientService;
        private EmployeeService employeeService;

        [BindProperty]
        public  Model.Counceling Counceling { get; set; }

        [BindProperty]
        public Model.Client Client { get; set; }

        [BindProperty]
        public Model.Employee Employee { get; set; }
        public AddClientModel(CouncelingService councelingService, ClientService clientService, EmployeeService employeeService) //Dependency Injection
        {
            this.councelingService = councelingService;
            this.clientService = clientService;
            this.employeeService = employeeService;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPostEmployee()
        {
            if (ModelState.IsValid)
            {
                employeeService.GetEmployees();
                return Page();
            }

            return null;
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                employeeService.GetEmployees();
                return Page();
            }

            if (clientService.CheckPhone(Client.Phone) == null)
            {
                await clientService.AddClientAsync(Client);
                Counceling.Client = Client;
                await councelingService.AddCouncelingAsync(Counceling);
                return RedirectToPage("GetAllCounceling");
            }
            else
            {
                Counceling.Client = Client;
                await councelingService.AddCouncelingAsync(Counceling);
                return RedirectToPage("GetAllCounceling");
            }
        }
    }
}
