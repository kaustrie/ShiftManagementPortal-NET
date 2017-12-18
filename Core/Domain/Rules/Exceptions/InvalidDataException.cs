using System;
using System.Collections.Generic;
using System.Text;

namespace ShiftManagementPortal.Core.Domain.Rules.Exceptions
{
    public class InvalidDataException: Exception
    {
        public InvalidDataException(string message) : base(message)
        {

        }
    }
}
