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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ParticipantID { get; set; }
        [Required]
        [ForeignKey("EventID")]
        public int EventID { get; set; }
        [Required]
        public Event Event { get; set; }
        public Participant():base()
        {
            
        }

        public Participant( int eventId)
        {
            EventID = eventId;
        }
    }
}
