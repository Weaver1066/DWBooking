using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DWBooking.Model
{
    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public Person()
        {
            
        }
        public Person(int id, string name, string phone, string email)
        {
            ID = id;
            Name = name;
            Phone = phone;
            Email = email;
        }
    }
}
