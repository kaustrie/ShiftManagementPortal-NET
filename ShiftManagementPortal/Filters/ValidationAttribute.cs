using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ShiftManagementPortal.API.Models;

namespace ShiftManagementPortal.API.Filters
{
    public class ValidationAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            base.OnActionExecuting(actionContext);

            if (!actionContext.ModelState.IsValid)
            {
                var errors = actionContext.ModelState
                    .Where(e => e.Value.Errors.Count > 0)
                    .Select(e => new RequestErrorModel() { Field = e.Key, Message = e.Value.Errors.First().ErrorMessage })
                    .ToArray();

                actionContext.Result = new BadRequestObjectResult(errors);
            }

        }
    }
}
