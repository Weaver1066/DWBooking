﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DWBooking.Model
{
    public class Employee : Person
    {
        [Required]
        public DateTime Age { get; set; }
        [Required]
        [StringLength(50)]
        public string Address { get; set; }
        [Required]
        [StringLength(50)]
        public int Role { get; set; }

        public Employee() :base()
        {
            
        }

        public Employee(int id, string name, string phone, string email, DateTime age, string address, int role) : base(id, name, phone, email)
        {
            Age = age;
            Address = address;
            Role = role;
        }
    }
}
