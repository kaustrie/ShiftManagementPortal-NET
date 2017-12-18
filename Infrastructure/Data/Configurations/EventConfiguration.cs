using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ShiftManagementPortal.Core.Domain.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShiftManagementPortal.Infrastructure.Data.Configurations
{
    internal class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(v => v.Id);
            builder.HasMany(e => e.Merchants);

        }
    }
}
