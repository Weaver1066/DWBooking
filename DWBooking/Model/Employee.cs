using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DWBooking.Model
{
    public class Employee : Person
    {
        public string Age { get; set; }

        public string Address { get; set; }

        public int Role { get; set; }


        public Employee() : base()
        {
            
        }

        public Employee(string age, string address, int role, int id, string name, string phone, string email) : base(id, name, phone, email)
        {
            Age = age;
            Address = address;
            Role = role;
        }
    }
}
