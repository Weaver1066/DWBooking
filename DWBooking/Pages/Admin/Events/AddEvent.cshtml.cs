using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using DWBooking.Model;
using DWBooking.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DWBooking.Pages.Admin.Events
{
    public class AddEventModel : PageModel
    {
        private EventService eventService;
        [BindProperty] public Event Event { get; set; }
        [BindProperty] public DateTime Date { get; set; }
        [BindProperty] public DateTime Time { get; set; }

        public AddEventModel(EventService eventService)
        {
            this.eventService = eventService;
        }
        public IActionResult OnGet()
        {
            Date = DateTime.Now;
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            Event.Date = Convert.ToDateTime(Date.ToShortDateString() + " " + Time.ToShortTimeString());
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await eventService.AddEventAsync(Event);
            return RedirectToPage("GetAllEvents");
        }
    }
}
