using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DWBooking.Model;

namespace DWBooking.Services
{
    public class CouncelingService
    {
        private GenericDbService<Counceling> DbService { get; set; }

        //List is made static as there is no instance where a user require their own instance of the list.
        public static List<Counceling> CouncelingList { get; set; }

        public CouncelingService(GenericDbService<Counceling> dbService)
        {
            DbService = dbService;
            CouncelingList = MockData.MockCouncelings.GetMockCouncelings();
            foreach (Counceling e in CouncelingList)
            {
                DbService.AddObjectAsync(e);
            }
            CouncelingList = DbService.GetObjectsAsync().Result.ToList();
        }

        /// <summary>
        /// Adds event to the database and to the services eventlist
        /// </summary>
        /// <param name="counceling">the event to be added</param>
        /// <returns></returns>
        public async Task AddCouncelingAsync(Counceling counceling)
        {
            CouncelingList.Add(counceling);
            await DbService.AddObjectAsync(counceling);
        }

        /// <summary>
        /// Returns the Services CouncelingList
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Counceling> GetCouncelings()
        {
            return CouncelingList;
        }

    }
}
