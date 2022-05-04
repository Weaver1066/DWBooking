using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DWBooking.Model
{
    public class Participant : Person
    {
        [Required]
        [ForeignKey("EventID")]
        public int EventID { get; set; }
        public Participant():base()
        {
            
        }

        public Participant(int eventId)
        {
            EventID = eventId;
        }
    }
}
