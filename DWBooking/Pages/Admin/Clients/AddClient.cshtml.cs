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

        [BindProperty]
        public  Model.Counceling Counceling { get; set; }

        [BindProperty]
        public Model.Client Client { get; set; }


        public AddClientModel(CouncelingService councelingService, ClientService clientService) //Dependency Injection
        {
            this.councelingService = councelingService;
            this.clientService = clientService;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (clientService.CheckPhone(Client.Phone) == null)
            {
                await clientService.AddClientAsync(Client);
                await councelingService.AddCouncelingAsync(Counceling);
                return RedirectToPage("GetAllCounceling");
            }
            else
            {
                await councelingService.AddCouncelingAsync(Counceling);
                return RedirectToPage("GetAllCounceling");
            }
        }
    }
}
