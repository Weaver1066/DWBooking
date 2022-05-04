using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DWBooking.Model
{
    public class Client : Person
    {
        [Key]
        public int ClientID { get; set; }
        public Client(): base()
        {
            
        }

        public Client(int clientId) :base( )
        {
            ClientID = clientId;
        }
    }
}
