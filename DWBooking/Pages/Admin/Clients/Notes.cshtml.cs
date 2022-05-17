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
    public class NotesModel : PageModel
    {
        private CouncelingService councelingService;

        public NotesModel(CouncelingService councelingService)
        {
            this.councelingService = councelingService;
        }

        [BindProperty] public Model.Counceling Counceling { get; set; }
        public IActionResult OnGet(int id)
        {

            Counceling = councelingService.GetCouncelingById(id).Result;

            if (Counceling == null)
                return RedirectToPage("/NotFound"); //NotFound er ikke defineret endnu

            return Page();
            
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await councelingService.UpdateCouncelingAsync(Counceling);
            return RedirectToPage("GetAllClients");
        }

    }
}
