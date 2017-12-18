using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShiftManagementPortal.Core.Domain.Model;

namespace ShiftManagementPortal.Infrastructure.Data.Configurations
{
    internal class MerchantConfiguration : IEntityTypeConfiguration<Merchant>
    {
        public void Configure(EntityTypeBuilder<Merchant> builder)
        {
            builder.HasKey(m => m.Id);
            var merchantAddress = builder.OwnsOne(m => m.Address);
            merchantAddress.Property(p => p.Line1).HasField("_line1").HasColumnName("Line1");
            merchantAddress.Property(p => p.Line2).HasField("_line2").HasColumnName("Line2");
            merchantAddress.Property(p => p.City).HasField("_city").HasColumnName("City");
            merchantAddress.Property(p => p.StateCode).HasField("_stateCode").HasColumnName("StatusCode");
            merchantAddress.Property(p => p.ZipCode).HasField("_zipCode").HasColumnName("ZipCode");
        }
    }
}
