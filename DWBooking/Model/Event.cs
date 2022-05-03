using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DWBooking.Model
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }

        public Event()
        {
            
        }

        public Event(int id, string name, string description, DateTime date, string type)
        {
            Id = id;
            Name = name;
            Description = description;
            Date = date;
            Type = type;    
        }
    }
}
