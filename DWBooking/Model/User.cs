using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DWBooking.Model
{
    public class User
    {
        [Key]
        [StringLength(50)]
        public string Username { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        public User()
        {
            
        }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
