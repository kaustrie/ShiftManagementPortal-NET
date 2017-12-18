using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShiftManagementPortal.Core.Domain.Model;

namespace ShiftManagementPortal.Infrastructure.Data.Configurations
{
    internal class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(c => c.Id);
            var contactAddress = builder.OwnsOne(c => c.Address);
            contactAddress.Property(p => p.Line1).HasField("_line1").HasColumnName("Line1");
            contactAddress.Property(p => p.Line2).HasField("_line2").HasColumnName("Line2");
            contactAddress.Property(p => p.City).HasField("_city").HasColumnName("City");
            contactAddress.Property(p => p.StateCode).HasField("_stateCode").HasColumnName("StatusCode");
            contactAddress.Property(p => p.ZipCode).HasField("_zipCode").HasColumnName("ZipCode");
        }
    }
}
