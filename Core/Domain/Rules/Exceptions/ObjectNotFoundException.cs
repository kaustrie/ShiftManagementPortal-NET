using System;
using System.Collections.Generic;
using System.Text;

namespace ShiftManagementPortal.Core.Domain.Rules.Exceptions
{
    public class ObjectNotFoundException: Exception
    {
        public ObjectNotFoundException(string message) : base(message)
        {

        }
    }
}
