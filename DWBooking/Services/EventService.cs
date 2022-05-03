using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DWBooking.Model;

namespace DWBooking.Services
{
    public class EventService
    {
        public GenericDbService<Event> DbService { get; set; }
        
        //List is made static as there is no instance where a user require their own instance of the list.
        public static List<Event> EventList { get; set; }
        public EventService(GenericDbService dbService)
        {
            DbService = dbService;
        }

        public 
    }
}
