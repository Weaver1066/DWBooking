using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DWBooking.Model;
using RestSharp;

namespace DWBooking.Services
{
    public class NotificationService
    {
        private EventService Eventservice;
        private ParticipantService ParticipantService;
        private CouncelingService CouncelingService;

        private List<Event> EventList { get; set; }
        private List<Participant> ParticipantList { get; set; }
        private List<Counceling> CouncelingList { get; set; }

        public NotificationService(EventService eventService, ParticipantService participantService, CouncelingService councelingService)
        {
            Eventservice = eventService;
            ParticipantService = participantService;
            CouncelingService = councelingService;
        }

        /// <summary>
        /// Checks the list of events for any events in 2 days and if yes
        /// then sends everyone who has signed up a text reminder
        /// </summary>
        public async void EventNotification()
        {

            var client = new RestSharp.RestClient("https://gatewayapi.com/rest/");
            var apiToken = "RA7Ko7h0TMqK48i8ijq86k4QZO8tZfJDTTt_o8ligSLlE7DHrc0pBNqggmpRVgfX";
            client.Authenticator = new RestSharp.Authenticators
                .HttpBasicAuthenticator(apiToken, "");
            List<string> phoneNumbersList = new List<string>();
            var request = new RestSharp.RestRequest("mtsms", RestSharp.Method.Post);
            EventList = Eventservice.GetEvents().ToList();
            TimeSpan TimeInterval1 = new TimeSpan(1, 0, 0, 0);
            string CurrentDate = DateTime.Now.ToString("dd-MM-yyyy");
            foreach (var Events in EventList)
            {
                if (Events.Date.ToString("dd-MM-yyyy") == Convert.ToDateTime(CurrentDate).AddDays(2).ToString("dd-MM-yyyy"))
                {
                    ParticipantList = ParticipantService.GetParticipantsByEvent(Events.EventID).ToList();

                    foreach (Participant participants in ParticipantList)
                    {
                        string message =
                            $"Hej. Dette er en påmindelse om {Events.Name} den {Events.Date.ToShortDateString()}  Mvh Diversity Works";
                        request.AddJsonBody(new
                        {

                            sender = "DW",
                            message = message,

                            recipients = new[] { new { msisdn = participants.Phone} }
                        });
                        var response = await client.ExecuteAsync(request);
                    }
                }
            }
            Thread.Sleep(TimeInterval1);
            EventNotification();
        }


        /// <summary>
        /// Checks the list of Counclings to see if there are any in 2 days and if yes sends
        /// the client a text to remind them.
        /// </summary>
        public async void ClientNotification()
        {
            var client = new RestSharp.RestClient("https://gatewayapi.com/rest/");
            var apiToken = "RA7Ko7h0TMqK48i8ijq86k4QZO8tZfJDTTt_o8ligSLlE7DHrc0pBNqggmpRVgfX";
            client.Authenticator = new RestSharp.Authenticators
                .HttpBasicAuthenticator(apiToken, "");
            List<string> phoneNumbersList = new List<string>();
            var request = new RestSharp.RestRequest("mtsms", RestSharp.Method.Post);
            CouncelingList = CouncelingService.GetCouncelingsAndEmplyeesAndClients().Result.ToList();
            TimeSpan TimeInterval2 = new TimeSpan(1, 0, 0, 0);
            string CurrentDate = DateTime.Now.ToString("dd-MM-yyyy");
            foreach (var Councelings in CouncelingList)
            {
                if (Councelings.Date.ToString("dd-MM-yyyy") == Convert.ToDateTime(CurrentDate).AddDays(2).ToString("dd-MM-yyyy"))
                {

                    foreach (Counceling counclings in CouncelingList)
                    {
                        request.AddJsonBody(new
                        {
                            sender = "DW",
                            message = "Hej. Vi skriver til dig for at påminde om den tid du har bestilt " + counclings.Date.ToShortDateString()+ " til en samtale. Hvis du har brug for at aflyse kan du ringe 35 39 69 85. Mvh Diversity Works",
                            recipients = new[] { new { msisdn = counclings.Client.Phone } }
                        });
                        var response = await client.ExecuteAsync(request);
                    }
                }
            }

            Thread.Sleep(TimeInterval2);
            ClientNotification();

        }
    }
}
