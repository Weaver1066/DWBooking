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
        private ClientService ClientService;

        private List<Event> EventList { get; set; }
        private List<Participant> ParticipantList { get; set; }
        private List<Counceling> CouncelingList { get; set; }
        private List<Client> ClientList { get; set; }

        public NotificationService(EventService eventService, ParticipantService participantService, CouncelingService councelingService, ClientService clientService)
        {
            Eventservice = eventService;
            ParticipantService = participantService;
            CouncelingService = councelingService;
            ClientService = clientService;
        }

        public async void EventNotification()
        {

            var client = new RestSharp.RestClient("https://gatewayapi.com/rest/");
            var apiToken = "RA7Ko7h0TMqK48i8ijq86k4QZO8tZfJDTTt_o8ligSLlE7DHrc0pBNqggmpRVgfX";
            client.Authenticator = new RestSharp.Authenticators
                .HttpBasicAuthenticator(apiToken, "");
            List<string> phoneNumbersList = new List<string>();
            var request = new RestSharp.RestRequest("mtsms", RestSharp.Method.Post);
            EventList = Eventservice.GetEvents().ToList();
            TimeSpan TimeInterval = new TimeSpan(1, 0, 0, 0);
            string CurrentDate = DateTime.Now.ToString("dd-MM-yyyy");
            foreach (var Events in EventList)
            {
                if (Events.Date.ToString("dd-MM-yyyy") == Convert.ToDateTime(CurrentDate).AddDays(2).ToString("dd-MM-yyyy"))
                {
                    ParticipantList = ParticipantService.GetParticipantsByEvent(Events.EventID).ToList();

                    foreach (Participant participants in ParticipantList)
                    {
                        request.AddJsonBody(new
                        {
                            sender = "Diversity Works",
                            message = "Hello World",
                            recipients = new[] { new { msisdn = participants.Phone} }
                        });
                        var response = await client.ExecuteAsync(request);
                    }
                }
            }
            Thread.Sleep(TimeInterval);
            EventNotification();
        }
        public async void ClientNotification()
        {
            var client = new RestSharp.RestClient("https://gatewayapi.com/rest/");
            var apiToken = "RA7Ko7h0TMqK48i8ijq86k4QZO8tZfJDTTt_o8ligSLlE7DHrc0pBNqggmpRVgfX";
            client.Authenticator = new RestSharp.Authenticators
                .HttpBasicAuthenticator(apiToken, "");
            List<string> phoneNumbersList = new List<string>();
            var request = new RestSharp.RestRequest("mtsms", RestSharp.Method.Post);
            CouncelingList = CouncelingService.GetCouncelingsAndEmplyeesAndClients().Result.ToList();
            TimeSpan TimeInterval = new TimeSpan(1, 0, 0, 0);
            string CurrentDate = DateTime.Now.ToString("dd-MM-yyyy");
            foreach (var Councelings in CouncelingList)
            {
                if (Councelings.Date.ToString("dd-MM-yyyy") == Convert.ToDateTime(CurrentDate).AddDays(2).ToString("dd-MM-yyyy"))
                {

                    foreach (Counceling counclings in CouncelingList)
                    {
                        request.AddJsonBody(new
                        {
                            sender = "Diversity Works",
                            message = "Hello World",
                            recipients = new[] { new { msisdn = counclings.Client.Phone } }
                        });
                        var response = await client.ExecuteAsync(request);
                    }
                }
            }
            Thread.Sleep(TimeInterval);
            ClientNotification();

        }
    }
}
