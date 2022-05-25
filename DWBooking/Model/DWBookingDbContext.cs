using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DWBooking.Model
{
    public class DWBookingDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(
                @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DWSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Counceling> Councelings { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<EventEmployees> EventEmployees { get; set; }
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Makes Composite Key for the Table EventEmployees
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventEmployees>()
                .HasKey(p => new { p.EventID, p.EmployeeID });
        }
    }
}
