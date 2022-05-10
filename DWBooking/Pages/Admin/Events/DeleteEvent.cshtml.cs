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
    public class DeleteEventModel : PageModel
    {
        private EventService eventService;

        [BindProperty] public Event Event { get; set; }

        public DeleteEventModel(EventService eventService)
        {
            this.eventService = eventService;
        }
        public IActionResult OnGet(int id)
        {
            Event = eventService.GetEventById(id);
            if (Event == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Event = eventService.GetEventById(id);
            await eventService.DeleteEventAsync(Event.EventID);
            return RedirectToPage("GetAllEvents");
        }
    }
}
