using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DWBooking.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DWBooking.Pages.Bruger.UserEvent
{
    public class GetEventModel : PageModel
    {
        private EventService eventService;

        public List<Model.Event> Events { get; set; }

        public GetEventModel(EventService eventService)
        {
            this.eventService = eventService;
        }
        public IActionResult OnGet()
        {
            Events = eventService.GetEvents().ToList();
            return Page();
        }
    }
}
