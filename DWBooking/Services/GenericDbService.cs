using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DWBooking.Interface;

namespace DWBooking.Services
{
    public class GenericDbService<T> : Iservice<T> where T : class
    {
        public async Task<IEnumerable<T>> GetObjectsAsync()
        {
            using (var context = new VagtPlanDbContext())
            {
                return await context.Set<T>().AsNoTracking().ToListAsync();
            }
        }

        public async Task AddObjectAsync(T obj)
        {
            using (var context = new VagtPlanDbContext())
            {
                context.Set<T>().Add(obj);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteObjectAsync(T obj)
        {
            using (var context = new VagtPlanDbContext())
            {
                context.Set<T>().Remove(obj);
                await context.SaveChangesAsync();
            }
        }

        public Task UpdateObjectAsync(T obj)
        {
            using (var context = new VagtPlanDbContext())
            {

            }

            throw new NotImplementedException();
        }

        public async Task<T> GetObjectByIdAsync(int id)
        {
            using (var context = new VagtPlanDbContext())
            {
                context.Set<T>().FindAsync(id);
                await context.SaveChangesAsync();
            }

            throw new Exception("no id found");
        }
    }
}
