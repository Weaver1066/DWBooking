using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DWBooking.Model;
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
        public List<Model.Employee> Employees { get; private set; }

        [BindProperty] public string SearchString { get; set; }
        [BindProperty] public DateTime Date { get; set; }
        [BindProperty] public DateTime Time { get; set; }

        [BindProperty] public  Model.Counceling Counceling { get; set; }
        [BindProperty] public Model.Client Client { get; set; }
        [BindProperty] public Model.Employee Employee { get; set; }
        public AddClientModel(CouncelingService councelingService, ClientService clientService, EmployeeService employeeService) //Dependency Injection
        {
            this.councelingService = councelingService;
            this.clientService = clientService;
            this.employeeService = employeeService;
        }
        public IActionResult OnGet()
        {
            Employees = employeeService.GetEmployees().ToList();
            return Page();
        }

        public async Task<IActionResult> OnPostCreateCounceling()
        {
            Employees = employeeService.GetEmployees().ToList();
            Counceling.Date = Convert.ToDateTime(Counceling.Date.ToShortDateString() + " " + Time.ToShortTimeString());
            if (clientService.CheckPhone(Client.Phone) == null)
            {
                await clientService.AddClientAsync(Client);
            }
            Client = clientService.CheckPhone(Client.Phone);
            Counceling.ClientID = Client.ClientID;
            Employee = employeeService.GetEmployee(Employee.EmployeeID);
            Counceling.EmployeeID = Employee.EmployeeID;


            await councelingService.AddCouncelingAsync(Counceling);
                return RedirectToPage("../Counceling/GetAllCounceling");
        }

        public IActionResult OnPostNameSearch()
        {
            Employees = employeeService.GetEmployees().ToList();
            Client = clientService.SearchClientName(SearchString);
            return Page();
        }
    }
}
