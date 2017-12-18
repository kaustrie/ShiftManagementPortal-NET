using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShiftManagementPortal.API.Models
{
    /// <summary>
    /// Model class to return field validation errors on model
    /// </summary>
    public class RequestErrorModel
    {
        /// <summary>
        /// The name of the field with an issue.
        /// </summary>
        public string Field { get; set; }

        /// <summary>
        /// A message containing a description of the error
        /// </summary>
        public string Message { get; set; }
    }
}
