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
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
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
