using System;
using System.Collections.Generic;
using System.Text;
using ShiftManagementPortal.Core.SeedWork;

namespace ShiftManagementPortal.Core.Domain.Model
{
    public class SignUp: Entity
    {
        public long EventId { get; set; }
        public long EmployeeId { get; set; }
    }
}
