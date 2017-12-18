using System;
using System.Collections.Generic;
using System.Text;
using ShiftManagementPortal.Core.SeedWork;

namespace ShiftManagementPortal.Core.Domain.Model
{
    public class EmployeeId : ValueObject<EmployeeId>
    {
        public long Id { get; }

        public EmployeeId(long id)
        {
            Id = id;
        }
        protected override bool EqualsCore(EmployeeId other)
        {
            return Id == other.Id;
        }

        protected override int GetHashCodeCore()
        {
            return base.GetHashCode();
        }
    }
}
