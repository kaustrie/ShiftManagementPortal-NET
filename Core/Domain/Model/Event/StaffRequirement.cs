using System;
using System.Collections.Generic;
using System.Text;
using ShiftManagementPortal.Core.SeedWork;

namespace ShiftManagementPortal.Core.Domain.Model
{
    public class StaffRequirement: ValueObject<StaffRequirement>
    {
        public int TotalCustodians { get; set; }
        public int TotalFullUshers { get; set; }
        public int TotalHeadUshers { get; set; }
        public int TotalPartialUshers { get; set; }

        protected override bool EqualsCore(StaffRequirement other)
        {
            throw new NotImplementedException();
        }

        protected override int GetHashCodeCore()
        {
            throw new NotImplementedException();
        }
    }
}
