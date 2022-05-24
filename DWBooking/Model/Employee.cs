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
        [Required(ErrorMessage = "Feltet skal udfyldes")]
        public DateTime Age { get; set; }
        [Required(ErrorMessage = "Feltet skal udfyldes")]
        [StringLength(50)]
        public string Address { get; set; }
        [Required(ErrorMessage = "Feltet skal udfyldes")]
        public int Role { get; set; }
        [ForeignKey("UserID")]
        public User? User { get; set; }
        public int? UserID { get; set; }


        public Employee() :base()
        {
            
        }
        public Employee(string name, string phone, string email, DateTime age, string address, int role) : base(name, phone, email)
        {
            Age = age;
            Address = address;
            Role = role;
        }
        public Employee( string name, string phone, string email, DateTime age, string address, int role, User user) : base( name, phone, email)
        {
            Age = age;
            Address = address;
            Role = role;
            User = user;
        }


        /// <summary>
        /// Converts the role integer into text
        /// </summary>
        /// <returns>string role</returns>
        public string ConvertRoleToString()
        {
            if (Role == 1)
                return "Admin";
            else if (Role == 2)
                return "Rådgiver";
            else if (Role == 3)
                return "Frivillig";
            else
                return null;
        }

        /// <summary>
        /// Converts a date of birth into age in years
        /// </summary>
        /// <returns>returns age as integer</returns>

        public int ConvertBirthdateToAge()
        {
            int age;
            age = DateTime.Now.Subtract(Age).Days;
            age /= 365;
            return age;
        }
    }
}
