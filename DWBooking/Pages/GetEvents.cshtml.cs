using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DWBooking.Pages.Admin.Events;
using DWBooking.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DWBooking.Pages
{
    public class GetEventsModel : PageModel
    {
        private EventService eventService;

        public List<Model.Event> Events { get; set; }

        public GetEventsModel(EventService eventService)
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
