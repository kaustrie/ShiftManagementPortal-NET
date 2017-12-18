using System;
using System.Collections.Generic;
using System.Text;
using ShiftManagementPortal.Core.SeedWork;

namespace ShiftManagementPortal.Core.Domain.Model
{
    public class EventId : ValueObject<EventId>
    {
        public long Id { get; }

        public EventId(long id)
        {
            Id = id;
        }

        protected override bool EqualsCore(EventId other)
        {
            return Id == other.Id;
        }

        protected override int GetHashCodeCore()
        {
            return base.GetHashCode();
        }
    }
}
