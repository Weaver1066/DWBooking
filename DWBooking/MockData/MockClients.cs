using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DWBooking.Model;

namespace DWBooking.MockData
{
    public class MockClients
    {
        private static List<Client> MockClientsList { get; set; } = new List<Client>()
        {
                new Client("Jones", "38475647", "jones@jsjs")
        };

        public static List<Client> GetMockClients()
        {
            return MockClientsList;
        }
    }
}
