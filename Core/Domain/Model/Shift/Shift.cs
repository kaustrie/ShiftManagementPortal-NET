using System;
using System.Collections.Generic;
using System.Text;
using ShiftManagementPortal.Core.SeedWork;

namespace ShiftManagementPortal.Core.Domain.Model
{
    public class Shift: ValueObject<Shift>
    {
        public EmployeeId EmployeeId { get; }
        public string Type { get; }

        public Shift(EmployeeId employeeId, string type)
        {
            EmployeeId = employeeId;
            Type = type;
        }

        protected override bool EqualsCore(Shift other)
        {
            return EmployeeId.Equals(other.EmployeeId)
                   && Type == other.Type;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                var hashCode = EmployeeId.GetHashCode();
                hashCode = (hashCode * 397) ^ Type.GetHashCode();

                return hashCode;
            }
        }
    }
}
