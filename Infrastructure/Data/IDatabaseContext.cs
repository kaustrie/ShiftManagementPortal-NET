using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ShiftManagementPortal.Core.Domain.Model;

namespace ShiftManagementPortal.Infrastructure.Data
{
    public interface IDatabaseContext
    {
        DbSet<Venue> Venues { get; set; }
        DbSet<Event> Events { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<Employee> Employees { get; set; }
        DbSet<Contact> Contacts { get; set; }
        DbSet<Merchant> Merchants { get; set; }
    }
}