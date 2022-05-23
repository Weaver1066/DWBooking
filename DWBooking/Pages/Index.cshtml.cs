using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DWBooking.Model;
using DWBooking.Services;

namespace DWBooking.Pages
{
    public class IndexModel : PageModel
    {
        private NotificationService NotificationService;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, NotificationService notificationService)
        {
            _logger = logger;
            NotificationService = notificationService;
        }

        public IActionResult OnGet()
        {
            //NotificationService.EventNotification();
            //NotificationService.ClientNotification();
           return RedirectToPage("/Bruger/UserEvent/GetEvent");
        }
    }
}
