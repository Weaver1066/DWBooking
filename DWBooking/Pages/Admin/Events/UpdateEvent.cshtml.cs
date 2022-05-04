using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DWBooking.Model;
using DWBooking.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DWBooking.Pages.Admin.Events
{
    public class UpdateEventModel : PageModel
    {
        private EventService eventService;

        [BindProperty] public Event Event { get; set; }
        [BindProperty] public DateTime Date { get; set; }
        [BindProperty] public DateTime Time { get; set; }
        public UpdateEventModel(EventService eventService)
        {
            this.eventService = eventService;
        }

        public IActionResult OnGet(int id)
        {
            Event = eventService.GetEventById(id);
            Date = Event.Date;
            Time = Event.Date;
            if (Event == null)
                return RedirectToPage("/NotFound"); //NotFound er ikke defineret endnu

            return Page();
        }
        public async Task<IActionResult> OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Event.EventID = id;
            Event.Date = Convert.ToDateTime(Date.ToShortDateString() + " " + Time.ToShortTimeString());
            await eventService.UpdateEventAsync(Event);
            return RedirectToPage("GetAllEvents");
        }
    }
}
