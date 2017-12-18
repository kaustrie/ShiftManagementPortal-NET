using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShiftManagementPortal.Core.Domain.Model;
using ShiftManagementPortal.Infrastructure.Data.Configurations;

namespace ShiftManagementPortal.Infrastructure.Data
{
    public class Database : DbContext, IDatabaseContext
    {
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Merchant> Merchants { get; set; }

        public Database(DbContextOptions<Database> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ForSqlServerUseSequenceHiLo("DBSequenceHiLo");

            modelBuilder.ApplyConfiguration(new ContactConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new EventConfiguration());
            modelBuilder.ApplyConfiguration(new MerchantConfiguration());
            modelBuilder.ApplyConfiguration(new VenueConfiguration());

            modelBuilder.Ignore<Shift>();
            modelBuilder.Ignore<SignUp>();
        }
    }
}
