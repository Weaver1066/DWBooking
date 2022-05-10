using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DWBooking.Model;
using DWBooking.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DWBooking.Pages.User.UserEvents
{
    public class GetParticipantsByEventModel : PageModel
    {
        public IEnumerable<Participant> Participants { get; set; }

        private ParticipantService participantService;
        public void OnGet()
        {
        }
    }
}
