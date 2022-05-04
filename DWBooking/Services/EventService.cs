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
        public EventService(GenericDbService<Event> dbService)
        {
            DbService = dbService;
            EventList = MockData.MockEvents.GetMockEvents();
        }

        /// <summary>
        /// Adds event to the database and to the services eventlist
        /// </summary>
        /// <param name="e">the event to be added</param>
        /// <returns></returns>
        public async Task AddEventAsync(Event e)
        {
            EventList.Add(e);
            await DbService.AddObjectAsync(e);
        }
        
        /// <summary>
        /// Returns the Services EventList
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Event> GetEvents()
        {
            return EventList;
        }

        /// <summary>
        /// Takes an int and returns the specific Event with that Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Event GetEventById(int id)
        {
            foreach (Event e in EventList)
            {
                if (e.Id == id) return e;
            }
            return null;
        }

        /// <summary>
        /// takes a specific event and uses the generic dbservice to update the data in the database
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public async Task UpdateEventAsync(Event e)
        {
            if (e != null)
            {
                //foreach (Event i in EventList)
                //{
                //    if (e.Id == i.Id)
                //    {
                //        i.Name = e.Name;
                //        i.Date = e.Date;
                //        i.Description = e.Description;
                //        i.Type = e.Type;
                //    }
                //}
                await DbService.UpdateObjectAsync(e);
            }
        }


        /// <summary>
        /// takes an id and deletes the event with the corresponding id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Event> DeleteEventAsync(int id)
        {
            Event eventToBeDeleted = null;
            foreach (Event e in EventList)
            {
                if (e.Id == id)
                {
                    eventToBeDeleted = e;
                    break;
                }
            }
            if (eventToBeDeleted != null)
            {
                EventList.Remove(eventToBeDeleted);
                await DbService.DeleteObjectAsync(eventToBeDeleted);
            }
            return eventToBeDeleted;
        }
    }
}
