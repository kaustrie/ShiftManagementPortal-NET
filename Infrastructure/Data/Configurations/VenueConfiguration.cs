using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShiftManagementPortal.Core.Domain.Model;

namespace ShiftManagementPortal.Infrastructure.Data.Configurations
{
    internal class VenueConfiguration : IEntityTypeConfiguration<Venue>
    {
        public void Configure(EntityTypeBuilder<Venue> builder)
        {
            builder.HasKey(v => v.Id);
            var venueAddress = builder.OwnsOne(v => v.Address);
            venueAddress.Property(p => p.Line1).HasField("_line1").HasColumnName("Line1");
            venueAddress.Property(p => p.Line2).HasField("_line2").HasColumnName("Line2");
            venueAddress.Property(p => p.City).HasField("_city").HasColumnName("City");
            venueAddress.Property(p => p.StateCode).HasField("_stateCode").HasColumnName("StatusCode");
            venueAddress.Property(p => p.ZipCode).HasField("_zipCode").HasColumnName("ZipCode");
        }
    }
}
