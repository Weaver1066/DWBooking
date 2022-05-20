using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace DWBooking.Model
{
    public class Person
    {
        private string _name;
        private string _phone;

        [Required]
        [StringLength(50)]
        public string Name
        {
            get { return _name;}
            set {CheckName(value);
                _name = value;
            }
        }

        [Required]
        [StringLength(10)]
        public string Phone
        {
            get { return _phone;} 
            set {CheckPhone(value);
                _phone = value;
            }
        }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        public Person()
        {
            
        }
        public Person( string name, string phone, string email)
        {
            CheckName(name);
            CheckPhone(phone);
            Name = name;
            Phone = phone;
            Email = email;
        }

        private static void CheckName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Navn kan ikke være tomt");
            }
            else if (name.Length > 50)
            {
                throw new ArgumentException("Navn må max være 50 tegn");
            }
        }

        private static void CheckPhone(string phone)
        {
            int temp;
            bool result = int.TryParse(phone, out temp);
            if (string.IsNullOrWhiteSpace(phone))
            {
                throw new ArgumentException("Telefon kan ikke være tomt");
            }
            else if (phone.Length != 8 || result == false)
            {
                throw new ArgumentException("nummeret skal være 8 tal");
            }
        }
    }
}
