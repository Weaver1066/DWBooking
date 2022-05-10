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
    public class GetAllClientsModel : PageModel
    {
        private ClientService clientService;
        public Client Client { get; set; }
        public List<Client> Clients { get; private set; }

        public GetAllClientsModel(ClientService clientService) //Dependency Injection
        {
            this.clientService = clientService;
        }

        public IActionResult OnGet()
        {
            Clients = clientService.GetClients().ToList();
            return Page();
        }
    }
}
