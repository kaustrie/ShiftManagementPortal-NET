using System;
using System.Collections.Generic;
using System.Text;

namespace ShiftManagementPortal.Core.Domain.Model
{
    public class Employee: Person
    {
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public IEnumerable<SignUp> SignUps { get; set; }
    }
}
