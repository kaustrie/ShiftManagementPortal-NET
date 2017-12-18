using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using ShiftManagementPortal.Infrastructure.Constants;

namespace ShiftManagementPortal.Controllers
{
    public abstract class BaseController : Controller
    {
        protected ILogger Logger;
        protected IMapper Mapper;
        

        public BaseController(ILogger<BaseController> logger, IMapper mapper) : base()
        {
            this.Logger = logger;
            this.Mapper = mapper;
        }


        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            //When controller begins to execute action, this will be available in context
            context.HttpContext.Items.Add(Constants.URLHELPER, this.Url);
                                                  }
    }
                                                               }