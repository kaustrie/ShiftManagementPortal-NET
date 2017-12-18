using System;
using System.Collections.Generic;
using System.Text;
using ShiftManagementPortal.Core.SeedWork;

namespace ShiftManagementPortal.Core.Domain.Model
{
    public class EventPostMortem: Entity
    {
        public long EventId { get; set; }
        public DateTime EndTimeActual { get; set; }
        public int TotalPatrons { get; set; }
        public string IncidentDetails { get; set; }
        public bool WasWaterSold { get; set; }
    }
}
