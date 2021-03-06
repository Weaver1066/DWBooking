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
    public class GetAllEventsModel : PageModel
    {
        private EventService eventService;

        public List<Event> Events { get; private set; }

        public GetAllEventsModel(EventService eventService) //Dependency Injection
        {
            this.eventService = eventService;
        }
        public IActionResult OnGet()
        {
            Events = eventService.SortByDateDescending().ToList();
            return Page();
        }
    }
}
