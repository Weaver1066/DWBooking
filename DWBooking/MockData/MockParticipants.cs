using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DWBooking.Model;

namespace DWBooking.MockData
{
    public class MockParticipants
    {
        private static List<Participant> MockParticipantsList { get; set; } = new List<Participant>()
        {

            new Participant(1, "Frederikke Sørensen", "13453248", "Personsmail@gmail.com"),
            new Participant(1, "Første navn", "32654392", "Personsmail12@gmail.com"),
            new Participant(1, "Andet navn", "12345678", "Personsmail123@gmail.com"),
            new Participant(1, "Tredje navn", "92846723", "Personsmail4324@gmail.com"),
            new Participant(1, "Fouth name", "23235454", "Personsmail123312@gmail.com"),
            new Participant(1, "Fifth name", "65834899", "Personsmail5435@gmail.com"),
            new Participant(1, "Sixth name", "12354388", "Personsmai435345l@gmail.com"),
            new Participant(2, "Seventh name", "3865491", "Personsmail543545@gmail.com"),
            new Participant(2, "Eight name", "231545", "Personsmail5425@gmail.com"),
            new Participant(3, "Ninth name", "6546567", "Personsmail34525@gmail.com"),
            new Participant(4, "Lotte Poulsen", "2456431", "Personsmail78769@gmail.com"),
            new Participant(4, "Henriette Mikkelsen", "54365821", "Personsmail89797@gmail.com"),
            new Participant(3, "Emperor Karl Franz", "13371337", "ReiklandForever@gmail.com")
        };

        public static List<Participant> GetMockParticipants()
        {
            return MockParticipantsList;
        }


    }
}
