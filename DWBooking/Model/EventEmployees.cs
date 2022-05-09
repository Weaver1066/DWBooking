using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DWBooking.Model
{
    public class EventEmployees
    {
        [Key] [ForeignKey("EventID")] public int EventID { get; set; } public Event Event { get; set; }
        [Key] [ForeignKey("EmployeeID")] public int EmployeeID { get; set; } public Employee Employee { get; set; }

        public EventEmployees()
        {
            
        }

        public EventEmployees(int eventId, int employeeId)
        {
            EventID = eventId;
            EmployeeID = employeeId;

        }
    }
}
