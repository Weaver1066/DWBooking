using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DWBooking.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DWBooking.Pages.Bruger.UserEvent
{
    public class AddParticipantModel : PageModel
    {
        private ParticipantService participantService;
        private List<Model.Participant> participants;

        [BindProperty]
        public Model.Participant Participant { get; set; }

        public AddParticipantModel(ParticipantService iss)
        {
            participantService = iss;
            //employees = MockData.MockEmployees.GetMockParticipants();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost(int id)
        {
            Participant.EventID = id;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await participantService.AddParticipantAsync(Participant);
            return RedirectToPage("GetEvent");
        }
    }
}
