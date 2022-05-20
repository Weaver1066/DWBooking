using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DWBooking.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DWBooking.Pages.Admin.Clients
{
    public class UpdateClientModel : PageModel
    {
        private ClientService ClientService;
        [BindProperty] public Model.Client Client { get; set; }

        public UpdateClientModel(ClientService clientService)
        {
            this.ClientService = clientService;
        }
        public IActionResult OnGet(int id)
        {
            Client = ClientService.GetClientById(id);
            return Page();
        }
        public async Task<IActionResult> OnPost(int id)
        {
            Client = ClientService.GetClientById(id);
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await ClientService.UpdateClientAsync(Client);
            return RedirectToPage("GetAllClients");
        }
    }
}
