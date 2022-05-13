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
        private CouncelingService councelingService;
        public Client Client { get; set; }
        public List<Client> Clients { get; private set; }
        [BindProperty] public string SearchString { get; set; }

        [BindProperty] public List<Model.Counceling> Councelings { get; set; }

        public GetAllClientsModel(ClientService clientService, CouncelingService councelingService) //Dependency Injection
        {
            this.clientService = clientService;
            this.councelingService = councelingService;
        }

        public IActionResult OnGet()
        {
            Clients = clientService.GetClients().ToList();
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            //Councelings = councelingService.GetCouncelingsByClient(id).ToList();
            return Page();
        }

        public IActionResult OnPostSearchName()
        {
            Clients = clientService.SearchClientsByName(SearchString).ToList();
            return Page();
        }
    }
}
