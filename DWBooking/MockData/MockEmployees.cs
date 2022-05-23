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
            new Employee("Gurli Martinussen", "84920341", "Gurli@Outlook.dk", new DateTime(1966, 06, 20), "Englandsvej 10", 1, new User("admin","admin")),
            new Employee("Jacob Scharf", "72839103", "Sharf@Outlook.dk", new DateTime(1972, 1, 28), "Haggisvej 20", 2, new User("tester", "tester")),
            new Employee("Mogens Hemmingsen", "32930142", "Hemmingsen@gmail.com", new DateTime(1965, 11, 28), "Godthåbsvej 15", 2, new User("Mogens", "Mogens")),
            new Employee("Sarah Hassani", "75473191", "S_Hassani@Outlook.dk", new DateTime(1990, 02, 22), "Frederiksberg allé 5", 2, new User("Sarah", "Sarah")),
            new Employee("Simon Pedersen", "11068888", "SP@hotmail.dk", new DateTime(1989, 03, 03), "Vedens allé 167", 3),
            new Employee("Souheila Hussein", "66728391", "S_Hussein@gmail.com", new DateTime(1986, 6, 21), "Christiansvej 11", 3),
            new Employee("Christian Sparrevohn", "64921002", "Sparrevohn@Outlook.dk", new DateTime(1992, 12, 24), "Julevej 18", 3) 
        };

        public static List<Employee> GetMockEmployees()
        {
            return employees;
        }
    }
    
}
