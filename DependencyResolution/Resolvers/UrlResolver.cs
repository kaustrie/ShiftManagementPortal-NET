using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShiftManagementPortal.Infrastructure.Constants;

namespace ShiftManagementPortal.DependencyResolution.Resolvers
{
    public class UrlResolver : IMemberValueResolver<object, object, RouteUrlInfo, string>
    {
        /// <summary>
        /// Creates a new Urlresolver class to be used during mapping resolution to create URL links
        /// </summary>
        /// <param name="httpContextAccessor">An IHttpContextAccessor object that allows this class to
        /// fetch the HttpContext of the current request</param>
        public UrlResolver(IHttpContextAccessor httpContextAccessor)
        {
            _httpContext = httpContextAccessor.HttpContext;
        }


        private readonly HttpContext _httpContext;


        /// <summary>
        /// Resolves a URL in a modul object by using a route name and route paramters in the supplied RouteUrlInfo object
        /// </summary>
        /// <param name="source">The source object we are mapping from.  Not used in this implementation</param>
        /// <param name="destination">The destination object we are mapping to.  Not used in this implementation</param>
        /// <param name="sourceMember">The RouteUrlInfo object of the route name and parameters we want to generate a URL for</param>
        /// <param name="destMember"></param>
        /// <param name="context"></param>
        /// <returns>A String of the generated URL</returns>
        public string Resolve(object source, object destination, RouteUrlInfo sourceMember, string destMember, ResolutionContext context)
        {
            IUrlHelper url = (IUrlHelper)_httpContext.Items[Constants.URLHELPER];

            return url.Link(sourceMember.RouteName, sourceMember.RouteParams);
        }
    }
}
