using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DWBooking.Model;
using DWBooking.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DWBooking.Pages.Admin.Clients
{
    public class GetCouncelingByClientModel : PageModel
    {
        private CouncelingService councelingService;
        private ClientService clientService;
        private EmployeeService employeeService;

        public List<Model.Counceling> Councelings { get; private set; }

        [BindProperty] public List<Model.Counceling> Councelingss { get; set; }
        [BindProperty] public Client Client { get; set; }

        public GetCouncelingByClientModel(CouncelingService councelingService)
        {
            this.councelingService = councelingService;
        }
        public async Task<IActionResult> OnGet(int id)
        {
            Councelings = councelingService.GetCouncelingsAndEmplyeesAndClients().Result.ToList();
            Councelings = councelingService.GetCouncelingsByClient(id, Councelings).ToList();
            return Page();
        }
    }
}
