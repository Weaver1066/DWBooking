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
            new Employee("Weaver Patrick", "84920341", "WeaverP@Outlook.dk", new DateTime(1995, 10, 2), "Englandsvej 10", 1, 20),
            new Employee("Torben Støger", "72839103", "TStøger@Outlook.dk", new DateTime(1985, 1, 28), "Haggisvej 20", 2, 21),
            new Employee("Anette Pedersen", "32930142", "AP@Outlook.dk", new DateTime(1997, 5, 8), "Københavnsvej 5", 3, 22)
        };

        public static List<Employee> GetMockEmployees()
        {
            return employees;
        }
    }
    
}
