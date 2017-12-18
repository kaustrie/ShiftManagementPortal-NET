using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShiftManagementPortal.Core.Domain.Model;

namespace ShiftManagementPortal.Infrastructure.Data.Configurations
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);
            var customerAddress = builder.OwnsOne(c => c.Address);
            customerAddress.Property(p => p.Line1).HasField("_line1").HasColumnName("Line1");
            customerAddress.Property(p => p.Line2).HasField("_line2").HasColumnName("Line2");
            customerAddress.Property(p => p.City).HasField("_city").HasColumnName("City");
            customerAddress.Property(p => p.StateCode).HasField("_stateCode").HasColumnName("StatusCode");
            customerAddress.Property(p => p.ZipCode).HasField("_zipCode").HasColumnName("ZipCode");
        }
    }
}
