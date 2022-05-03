using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DWBooking.Model;

namespace DWBooking.MockData
{
    public class MockEmployees
    {
        private static List<Employee> employees = new List<Employee>()
        {
            new Employee("28", "Københavnsvej 202", 1, new Person(21, "Lars Ole", "89048332", "LarsOle@Outlook.dk")),
            new Employee("31", "Englandsvej 21", 2, new Person(22, "Anette Pedersen", "63272301", "AnetteP@Outlook.dk")),
            new Employee("27", "Haggisgade 2", 3, new Person(23, "Patrick Weavs", "79247523", "PWeavs@Outlook.dk"))
        };

        public static List<Employee> GetMockEmployees()
        {
            return employees;
        }
    }
}
