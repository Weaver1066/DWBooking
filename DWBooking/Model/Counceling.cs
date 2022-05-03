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
        public int ID { get; set; }
        [Required]
        public string Notes { get; set; }
        [Required] 
        public DateTime Date { get; set; }
        [Required]
        [ForeignKey("EmployeeID")]
        public int EmployeeID { get; set; }
        [Required]
        [ForeignKey("ClientID")]
        public int ClientID { get; set; }

        public Counceling()
        {
            
        }

        public Counceling(int id, string notes, DateTime date, int employeeId, int clientId)
        {
            ID = id;
            Notes = notes;
            Date = date;
            EmployeeID = employeeId;
            ClientID = clientId;
        }
    }
}
