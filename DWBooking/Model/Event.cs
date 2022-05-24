using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DWBooking.Model
{
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventID { get; set; }
        [Required(ErrorMessage = "Feltet skal udfyldes")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Feltet skal udfyldes")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Feltet skal udfyldes")]
        //[Validation]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Feltet skal udfyldes")]
        [StringLength(50)]
        public string Type { get; set; }

        public Event()
        {
            
        }

        public Event( string name, string description, DateTime date, string type)
        {
            Name = name;
            Description = description;
            Date = date;
            Type = type;    
        }
    }
}
