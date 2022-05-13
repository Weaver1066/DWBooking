using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DWBooking.Model
{
    public class Counceling
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int CouncelingID { get; set; }
        public string Notes { get; set; }
        [Required] 
        public DateTime Date { get; set; }
        [Required]
        [ForeignKey("EmployeeID")]
        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }
        [Required]
        [ForeignKey("ClientID")]
        public int ClientID { get; set; }
        public Client Client { get; set; }

        public Counceling()
        {
            
        }

        public Counceling( string notes, DateTime date, int employeeId, int clientId)
        {
            Notes = notes;
            Date = date;
            EmployeeID = employeeId;
            ClientID = clientId;
        }

        public Counceling(int councelingId, string notes, DateTime date, int employeeId, Employee employee, int clientId, Client client)
        {
            CouncelingID = councelingId;
            Notes = notes;
            Date = date;
            EmployeeID = employeeId;
            Employee = employee;
            ClientID = clientId;
            Client = client;
        }
    }
}
