using System;
using System.Collections.Generic;
using System.Text;
using ShiftManagementPortal.Core.SeedWork;

namespace ShiftManagementPortal.Core.Domain.Model
{
    public class Venue: Entity, IAggregateRoot
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public Address Address { get; set; }
        public IEnumerable<Event> Events { get; set; }
    }
}
