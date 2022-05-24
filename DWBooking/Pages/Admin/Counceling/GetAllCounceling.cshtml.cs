using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DWBooking.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DWBooking.Pages.Admin.Counceling
{
    public class GetAllCouncelingModel : PageModel
    {
        private CouncelingService councelingService;
        private EmployeeService employeeService;
        private ClientService clientService;
        public List<Model.Counceling> Councelings { get; private set; }


        public GetAllCouncelingModel(CouncelingService councelingService) //Dependency Injection
        {
            this.councelingService = councelingService;
        }
        public async Task<IActionResult> OnGet()
        {
            Councelings = councelingService.GetCouncelingsAndEmplyeesAndClients().Result.ToList();
            Councelings = councelingService.SortByDateDescending(Councelings).ToList();
            return Page();
        }
        
    }
}
