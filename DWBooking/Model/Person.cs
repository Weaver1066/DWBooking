using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace DWBooking.Model
{
    public class Person
    {
        private string _name;
        private string _phone;
        private string _email;

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
        public string Email 
        {
            get { return _email; } 
            set { CheckMail(value); _email = value; } 
        }

        public Person()
        {
            
        }
        public Person( string name, string phone, string email)
        {
            CheckName(name);
            Name = name;
            CheckPhone(phone);
            Phone = phone;
            CheckMail(email);
            Email = email;
        }

        private static void CheckName(string name)
        {
            //if (string.IsNullOrWhiteSpace(name))
            //{
            //    throw new ArgumentException("Navn kan ikke være tomt");
            //}
            //else if (name.Length > 50)
            //{
            //    throw new ArgumentException("Navn må max være 50 tegn");
            //}
        }

        private static void CheckPhone(string phone)
        {
            //int temp;
            //bool result = int.TryParse(phone, out temp);
            //if (string.IsNullOrWhiteSpace(phone))
            //{
            //    throw new ArgumentException("Telefon kan ikke være tomt");
            //}
            //else if (phone.Length != 8 || result == false)
            //{
            //    throw new ArgumentException("nummeret skal være 8 tal");
            //}
        }

        private static void CheckMail(string email)
        { 
            //if ((new EmailAddressAttribute().IsValid(email)) == false)
            //{
            //    throw new ArgumentException("Dette er ikke en valid email");
            //}
        }


    }
}
