using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShiftManagementPortal.Core.Domain.Model;

namespace ShiftManagementPortal.Infrastructure.Data.Configurations
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);
            var employeeAddress = builder.OwnsOne(e => e.Address);
            employeeAddress.Property(p => p.Line1).HasField("_line1").HasColumnName("Line1");
            employeeAddress.Property(p => p.Line2).HasField("_line2").HasColumnName("Line2");
            employeeAddress.Property(p => p.City).HasField("_city").HasColumnName("City");
            employeeAddress.Property(p => p.StateCode).HasField("_stateCode").HasColumnName("StatusCode");
            employeeAddress.Property(p => p.ZipCode).HasField("_zipCode").HasColumnName("ZipCode");
        }
    }
}
