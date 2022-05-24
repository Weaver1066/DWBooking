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


        /// <summary>
        /// Updates the given councelings note property in the database and service list
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
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


        /// <summary>
        /// takes a counceling's id as int and returns the matching counceling
        /// </summary>
        /// <param name="id"></param>
        /// <returns>the counceling with the given id including the client and employee</returns>
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


        /// <summary>
        /// returns a list of all councelings including their employee and client
        /// </summary>
        /// <returns>a list of councelings including matching employee and client</returns>
        public async Task<IEnumerable<Counceling>> GetCouncelingsAndEmplyeesAndClients()
        {
            List<Counceling> templist = new List<Counceling>();

            using (var context = new DWBookingDbContext())
            {
                templist = context.Councelings.Include(u => u.Client).Include(i => i.Employee).AsNoTracking().ToList();
            }

            return templist;
        }


        /// <summary>
        /// takes a list of councelings and a date and removes all councelings where the date does not match
        /// </summary>
        /// <param name="date"></param>
        /// <param name="temp"></param>
        /// <returns>a list where all objects without matching dates have been removed</returns>
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

        /// <summary>
        /// takes a list of councelings and a client id and returns a list of councelings for the given client
        /// </summary>
        /// <param name="id"></param>
        /// <param name="temp"></param>
        /// <returns>a list of councelings for the client with the given id</returns>
        public IEnumerable<Counceling> GetCouncelingsByClient(int id, IEnumerable<Counceling> temp)
        {
            List<Counceling> templist = new List<Counceling>();
            foreach (var c in temp)
            {
                if (c.ClientID == id) templist.Add(c);
            }
            return templist;
        }

        /// <summary>
        /// takes a list and sourts it by date descending
        /// </summary>
        /// <param name="temp"></param>
        /// <returns>the given list sorted by date</returns>
        public IEnumerable<Counceling> SortByDateDescending(IEnumerable<Counceling> temp)
        {
            return from Counceling in temp
                orderby Counceling.Date descending
                select Counceling;
        }
    }
}
