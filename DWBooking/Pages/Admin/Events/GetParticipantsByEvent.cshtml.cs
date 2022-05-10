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
    public class GetParticipantsByEventModel : PageModel
    {
        private EventService eventService;
        private ParticipantService participantService;
        public List<Participant> Participants { get; set; }
        public Event Event { get; set; }

        public GetParticipantsByEventModel(EventService eventService, ParticipantService participantService)
        {
            this.eventService = eventService;
            this.participantService = participantService;
        }
        public void OnGet(int id)
        {
            Event = eventService.GetEventById(id);
            Participants = participantService.GetParticipantsByEvent(id).ToList();
        }
    }
}
