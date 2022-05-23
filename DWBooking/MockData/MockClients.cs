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
                new Client("Hulwi Salman", "38475647", "Hulwi@gmail.com"),
                new Client("Rabeea Yousuf", "45281829", "Rabeea@gmail.com"),
                new Client("Nathifa Shaikh", "98572912", "Nathifa@outlook.com"),
                new Client("Mada Nouri", "22882127", "MadaNouri@hotmail.com"),
                new Client("Aini Hamad", "45981233", "AiniHamad@hotmail.com"),
                new Client("Almasa Qasim", "99231676", "Almasa@gmail.com"),
                new Client("Sujah Hariri", "91293666", "Sujah@outlook.com"),
                new Client("Nuha Amber", "11218836", "NuhaAmber@gmail.com"),
                new Client("Saimah Shareef", "44182156", "Saimah@gmail.com"),
                new Client("Sawsan Mousa", "99882121", "Sawsan@gmail.com"),
        };

        public static List<Client> GetMockClients()
        {
            return MockClientsList;
        }
    }
}
