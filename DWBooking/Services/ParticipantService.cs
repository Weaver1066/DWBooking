using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DWBooking.Model;

namespace DWBooking.Services
{
    public class ParticipantService
    {
        public GenericDbService<Participant> DbService { get; set; }

        //List is made static as there is no instance where a user require their own instance of the list.
        public static List<Participant> ParticipantsList { get; set; }
        public ParticipantService(GenericDbService<Participant> dbService)
        {
            DbService = dbService;
            //ParticipantsList = MockData.MockParticipants.GetMockParticipants();
            //foreach (Participant e in ParticipantsList)
            //{
            //    DbService.AddObjectAsync(e);
            //}
            ParticipantsList = DbService.GetObjectsAsync().Result.ToList();
        }

        /// <summary>
        /// Adds Participant to the database and to the services ParticipantsList
        /// </summary>
        /// <param name="e">the event to be added</param>
        /// <returns></returns>
        public async Task AddParticipantAsync(Participant e)
        {
            ParticipantsList.Add(e);
            await DbService.AddObjectAsync(e);
        }

        /// <summary>
        /// Returns participants by eventId
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Participant> GetParticipantsByEvent(int id)
        {
            var query = ParticipantsList.Where(participant => participant.EventID == id).Select(participant => participant);
            List<Participant> temp = new List<Participant>();
            foreach (var i in query)
            {
                temp.Add(i);
            }
            return temp;
        }

        /// <summary>
        /// Takes an int and returns the specific Event with that Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Participant GetParticipantById(int id)
        {
            foreach (Participant e in ParticipantsList)
            {
                if (e.ParticipantID == id) return e;
            }
            return null;
        }

        /// <summary>
        /// takes an id and deletes the participant with the corresponding id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Participant> DeleteParticipantAsync(int id)
        {
            Participant participantToBeDeleted = null;
            foreach (Participant e in ParticipantsList)
            {
                if (e.ParticipantID == id)
                {
                    participantToBeDeleted = e;
                    break;
                }
            }
            if (participantToBeDeleted != null)
            {
                ParticipantsList.Remove(participantToBeDeleted);
                await DbService.DeleteObjectAsync(participantToBeDeleted);
            }
            return participantToBeDeleted;
        }
    }
}

