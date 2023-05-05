using AirLine.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirLine.Repositories.Data
{
    public class DBAContext : DbContext
    {
        public DBAContext(DbContextOptions<DBAContext> options) : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<AirCraft> AirCrafts { get; set; }
        public DbSet<AirLines> AirLines { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Flight> Flights { get; set; } 
        public DbSet<FlightSchedule> FlightSchedules { get; set; }
        public DbSet<PortsFrom> PortsFrom { get; set; }
        public DbSet<PortsTo> PortsTo { get; set; }
        public DbSet<PriceCategory> PriceCategories { get; set; }
    }
}
