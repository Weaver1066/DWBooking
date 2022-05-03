using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DWBooking.Interface
{

        interface Iservice<T>
        {

            Task<IEnumerable<T>> GetObjectsAsync();
            Task AddObjectAsync(T obj);
            Task DeleteObjectAsync(T obj);
            Task UpdateObjectAsync(T obj);
            Task<T> GetObjectByIdAsync(int id);
        }
    }

