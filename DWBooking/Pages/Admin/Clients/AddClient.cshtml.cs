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

        public  Model.Counceling Counceling { get; set; }
        public  Model.Client Client { get; set; }
        public List<Model.Counceling> Councelings { get; private set; }


        public AddClientModel(CouncelingService councelingService) //Dependency Injection
        {
            this.councelingService = councelingService;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            councelingService.AddCouncelingAsync(Counceling);
            return RedirectToPage("GetAllCounceling");
        }
    }
    
}
