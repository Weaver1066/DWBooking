using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DWBooking.Model;

namespace DWBooking.Services
{
    public class UserService
    {
        public List<User> Users { get; set; }
        public GenericDbService<User> DbService { get; set; }
        
        public UserService()
        {
            
        }

        //public void AddUser(Employee i)
        //{
        //    Users.Add(new User(i.Username, i.Password));
        //}

        public List<User> GetUsers()
        {
            return Users;
        }

    }
}
