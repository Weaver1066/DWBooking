using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DWBooking.Interface;
using DWBooking.Model;
using Microsoft.EntityFrameworkCore;

namespace DWBooking.Services
{
    public class GenericDbService<T> : Iservice<T> where T : class
    {
        public async Task<IEnumerable<T>> GetObjectsAsync()
        {
            using (var context = new DWBookingDbContext())
            {
                return await context.Set<T>().AsNoTracking().ToListAsync();
            }
        }
        /// <summary>
        /// Generic method to add a object to the database
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task AddObjectAsync(T obj)
        {
            using (var context = new DWBookingDbContext())
            {
                context.Set<T>().Add(obj);
                await context.SaveChangesAsync();
            }
        }
        /// <summary>
        /// Generic method to delete a object to the database
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task DeleteObjectAsync(T obj)
        {
            using (var context = new DWBookingDbContext())
            {
                context.Set<T>().Remove(obj);
                await context.SaveChangesAsync();
            }
        }
        /// <summary>
        /// Generic method that updates a  already existing object in the database
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task UpdateObjectAsync(T obj)
        {
            using (var context = new DWBookingDbContext())
            {
                context.Set<T>().Update(obj);
                await context.SaveChangesAsync();
            }
        }
        /// <summary>
        /// Finds and then gets a single object in the database  using its corresponding ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T> GetObjectByIdAsync(int id)
        {
            using (var context = new DWBookingDbContext())
            {
                context.Set<T>().FindAsync(id);
                await context.SaveChangesAsync();
            }

            throw new Exception("no id found");
        }
    }
}
