using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DWBooking.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.IdentityModel.Tokens;

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
            //CouncelingList = MockData.MockCouncelings.GetMockCouncelings();
            //foreach (Counceling e in CouncelingList)
            //{
            //    DbService.AddObjectAsync(e);
            //}

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

        public async Task UpdateCouncelingAsync(Counceling c)
        {
            if (c != null)
            {
                foreach (Counceling i in CouncelingList)
                {
                    if (i.CouncelingID == c.CouncelingID)
                    {
                        i.Notes = c.Notes;
                    }
                }
                await DbService.UpdateObjectAsync(c);
            }
        }

        public async Task<Counceling> GetCouncelingById(int id)
        {
            Counceling counceling;
            using (var context = new DWBookingDbContext())
            {
               counceling  = context.Councelings.Include(u => u.Client)
                   .Include(i => i.Employee)
                   .FirstOrDefault(u => u.CouncelingID == id);
            }

            return counceling;
        }

        public async Task<IEnumerable<Counceling>> GetCouncelingsAndEmplyeesAndClients()
        {
            List<Counceling> templist = new List<Counceling>();

            using (var context = new DWBookingDbContext())
            {
                templist = context.Councelings.Include(u => u.Client).Include(i => i.Employee).AsNoTracking().ToList();
            }

            return templist;
        }


        public IEnumerable<Counceling> GetCouncelingsByDate(DateTime date, IEnumerable<Counceling> temp)
        {
            List<Counceling> templist = new List<Counceling>();
            foreach (var c in temp)
            {
                if (c.Date.ToString("d") == date.ToString("d"))
                {
                    templist.Add(c);
                }
            }
            return templist;
        }

        public IEnumerable<Counceling> GetCouncelingsByClient(int id, IEnumerable<Counceling> temp)
        {
            List<Counceling> templist = new List<Counceling>();
            foreach (var c in temp)
            {
                if (c.ClientID == id) templist.Add(c);
            }
            return templist;
        }

    }
}
