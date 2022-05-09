using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DWBooking.Model
{
    public class Employee : Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeID { get; set; }
        [Required]
        public DateTime Age { get; set; }
        [Required]
        [StringLength(50)]
        public string Address { get; set; }
        [Required]
        [StringLength(50)]
        public int Role { get; set; }
        [ForeignKey("UserID")]
        public User? User { get; set; }
        public int? UserID { get; set; }


        public Employee() :base()
        {
            
        }

        public Employee( string name, string phone, string email, DateTime age, string address, int role, User user) : base( name, phone, email)
        {
            Age = age;
            Address = address;
            Role = role;
            User = user;
        }
        public Employee(string name, string phone, string email, DateTime age, string address, int role) : base(name, phone, email)
        {
            Age = age;
            Address = address;
            Role = role;
        }
    }
}
