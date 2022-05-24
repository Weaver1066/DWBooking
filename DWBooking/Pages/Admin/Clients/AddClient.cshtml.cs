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

        [BindProperty] public string PhoneError { get; set; }
        public AddClientModel(CouncelingService councelingService, ClientService clientService, EmployeeService employeeService) //Dependency Injection
        {
            this.councelingService = councelingService;
            this.clientService = clientService;
            this.employeeService = employeeService;
        }
        public IActionResult OnGet()
        {
            Date = DateTime.UtcNow;
            Employees = employeeService.GetEmployees().ToList();
            return Page();
        }

        public async Task<IActionResult> OnPostCreateCounceling()
        {
            Time = Convert.ToDateTime(Request.Form[("time")]);
            Counceling.Date = Convert.ToDateTime(Date.ToShortDateString() + " " + Time.ToShortTimeString());
            Employees = employeeService.GetEmployees().ToList();
            if(Client.Phone != null)
                Client = clientService.CheckPhone(Client.Phone);
            Counceling.ClientID = Client.ClientID;

            Employee = employeeService.GetEmployee(Employee.EmployeeID);
            Counceling.EmployeeID = Employee.EmployeeID;
            if (clientService.CheckPhone(Client.Phone) == null && Client.Name != null)
            {
                await clientService.AddClientAsync(Client);
            }
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}
            await councelingService.AddCouncelingAsync(Counceling);
                return RedirectToPage("../Counceling/GetAllCounceling");

        }

        public IActionResult OnPostNameSearch()
        {
            Date = DateTime.UtcNow;
            Employees = employeeService.GetEmployees().ToList();
            if(SearchString != null)
                Client = clientService.SearchClientName(SearchString);
            return Page();
        }
    }
}
