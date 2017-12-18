using System;
using System.Collections;
using System.Collections.Generic;
using ShiftManagementPortal.Core.SeedWork;

namespace ShiftManagementPortal.Core.Domain.Model
{
    public class Event: Entity, IAggregateRoot
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public long VenueId { get; set; }
        public DateTime ExpectedDuration { get; set; }
        public IEnumerable<Merchant> Merchants { get; set; }
        public bool IsReservedSeating { get; set; }
        public bool IsIntermission { get; set; }
        public bool IsPlaybillAvailable { get; set; }           
        public bool IsLobbyToBeDecorated { get; set; }
        public string Comment { get; set; }

        public int TotalCustodiansRequired { get; set; }
        public int TotalFullUshersRequired { get; set; }
        public int TotalHeadUshersRequired { get; set; }
        public int TotalPartialUshersRequired { get; set; }
        public bool IsEventShiftCollisionAllowed { get; set; }

        public IEnumerable<Shift> Shifts { get; set; }
        //public StaffRequirement StaffRequirement { get; set; }

    }
}
