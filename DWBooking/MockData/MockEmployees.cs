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
            new Employee(21, "Lars Ole", "89048332" ,"LarsOle@Outlook.dk", new DateTime(1992, 11, 2), "Københavnsvej 202", 1),
            new Employee(22, "Anette Pedersen", "83945931", "AnetteP@outlook.dk", new DateTime(1991, 5, 24), "Englandsvej 10", 2),
            new Employee(23, "Patrick Weavs", "32423495", "PWeavs@outlook.dk", new DateTime(1985, 6, 14), "Haggisvej 3", 3)
        };

        public static List<Employee> GetMockEmployees()
        {
            return employees;
        }
    }
}
