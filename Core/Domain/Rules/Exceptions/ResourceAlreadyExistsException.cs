using System;
using System.Collections.Generic;
using System.Text;

namespace ShiftManagementPortal.Core.Domain.Rules.Exceptions
{
    public class ResourceAlreadyExistsException: Exception
    {
        public ResourceAlreadyExistsException(String message) : base(message)
        {

        }
    }
}
