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

            public List<Model.Counceling> Councelings { get; private set; }

            public GetAllCouncelingModel(CouncelingService councelingService) //Dependency Injection
            {
                this.councelingService = councelingService;
            }
            public IActionResult OnGet()
            {
                try
                {
                    Councelings = councelingService.GetCouncelings().ToList();
                    return Page();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        
    }
}
