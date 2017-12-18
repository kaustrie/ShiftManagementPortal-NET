using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using ShiftManagementPortal.API.Models;
using ShiftManagementPortal.API.Results;
using ShiftManagementPortal.Core.Domain.Rules.Exceptions;

namespace ShiftManagementPortal.API.Filters
{
    public class ExceptionHandlerFilterAttribute : ExceptionFilterAttribute
    {
        private readonly ILogger _logger;

        public ExceptionHandlerFilterAttribute(ILoggerFactory loggerFactory)
        {
            this._logger = loggerFactory.CreateLogger(this.GetType().FullName);
        }

        public override void OnException(ExceptionContext context)
        {
            var ex = context.Exception;
            var logMessage = $"{ex.GetType().Name} occured in action {context.ActionDescriptor.DisplayName} - {ex.Message}";
            var errorHandlers = new Dictionary<Type, Action>
            {
                {
                    typeof(InvalidDataException),
                    () =>
                        {
                            _logger.LogError(new EventId(400), ex, logMessage);
                            var message = new ApiMessageModel() { Message = ex.Message };
                            context.Result = new BadRequestObjectResult(message);
                        }
                },
                {
                    typeof(SecurityException),
                    () =>
                    {
                        _logger.LogError(new EventId(403), ex, logMessage);
                        var message = new ApiMessageModel() { Message = "Access to this resource is forbidden" };
                        context.Result = new ForbiddenObjectResult(message);
                    }
                },
                {
                    typeof(ObjectNotFoundException),
                    () =>
                    {
                        _logger.LogError(new EventId(404), ex, logMessage);
                        var message = new ApiMessageModel() { Message = ex.Message };
                        context.Result = new NotFoundObjectResult(message);
                    }
                },
                {
                    typeof(ResourceAlreadyExistsException),
                    () =>
                    {
                        _logger.LogError(new EventId(409), ex, logMessage);
                        var message = new ApiMessageModel() { Message = ex.Message };
                        context.Result = new ConflictObjectResult(message);
                    }
                },
                {
                    typeof(Exception),
                    () =>
                    {
                        _logger.LogError(new EventId(500), ex, logMessage);
                        var message = new ApiMessageModel() { Message = "An error has occurred on the server.  " +
                                                                        "The error has been logged so it can be investigated by our support teams" };
                        context.Result = new InternalServerErrorObjectResult(message);
                    }
                }
            };

            var type = errorHandlers.ContainsKey(ex.GetType())
                ? ex.GetType()
                : errorHandlers.ContainsKey(ex.GetType().BaseType)
                    ? ex.GetType().BaseType
                    : typeof(Exception);
            errorHandlers[type].Invoke();

            context.ExceptionHandled = true;
        }
    }
}
