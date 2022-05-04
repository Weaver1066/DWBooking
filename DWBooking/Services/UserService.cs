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
        
        public UserService(GenericDbService<User> dbService)
        {
            DbService = dbService;
            Users = DbService.GetObjectsAsync().Result.ToList();
        }

        //public void AddUser(Employee )
        //{
        //    Users.Add(new User(Username, Password));
        //}

        public List<User> GetUsers()
        {
            return Users;
        }

    }
}
