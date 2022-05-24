using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DWBooking.Model;

namespace DWBooking.MockData
{
    public class MockCouncelings
    {
        private static List<Counceling> MockCouncelingList { get; set; } = new List<Counceling>()
        {
            new Counceling("Han var rigtig dårlig", DateTime.Now, 2345, 43),
        };

        public static List<Counceling> GetMockCouncelings()
        {
            return MockCouncelingList;
        }

    }
}
