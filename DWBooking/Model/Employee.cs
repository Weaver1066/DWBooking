using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DWBooking.Model
{
    public class Employee
    {
        public string Age { get; set; }

        public string Address { get; set; }

        public int Role { get; set; }

        public Employee()
        {
            
        }

        public Employee(string age, string address, int role)
        {
            Age = age;
            Address = address;
            Role = role;
        }
    }
}
