using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShiftManagementPortal.API.Models
{
    /// <summary>
    /// Model class to wrap messages returned by an API, especially error messages
    /// </summary>
    /// <remarks>
    /// Allows for messages to be returned as a JSON object instead of simple string.
    /// Can be extended to include other info like status code, id, etc
    /// </remarks>
    public class ApiMessageModel
    {
        public string Message { get; set; }
    }
}
