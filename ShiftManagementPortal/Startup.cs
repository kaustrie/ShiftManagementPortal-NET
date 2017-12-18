using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ShiftManagementPortal.API.Filters;
using ShiftManagementPortal.Core.Domain.Model;
using ShiftManagementPortal.DependencyResolution.Registries;
using ShiftManagementPortal.Infrastructure.Data;
using StructureMap;

namespace ShiftManagementPortal.API
{
    public class Startup
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly IHostingEnvironment _env;

        public Startup(IConfiguration configuration, ILoggerFactory loggerFactory, IHostingEnvironment env)
        {
            Configuration = configuration;
            _loggerFactory = loggerFactory;
            _env = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<Database>();
            services.Configure<IdentityOptions>(config =>
            {
               
            });
            services.ConfigureApplicationCookie(options =>
            {
                options.Events = new CookieAuthenticationEvents()
                {
                    OnRedirectToLogin = (ctx) =>
                    {
                        if (ctx.Request.Path.StartsWithSegments("/api") && ctx.Response.StatusCode == 200)
                        {
                            ctx.Response.StatusCode = 401;
                        }
                        return Task.CompletedTask;
                    },
                    OnRedirectToAccessDenied = (ctx) =>
                    {
                        if (ctx.Request.Path.StartsWithSegments("/api") && ctx.Response.StatusCode == 200)
                        {
                            ctx.Response.StatusCode = 403;
                        }
                        return Task.CompletedTask;
                    },
                };
            });
            services.AddCors(); //cross origin sharing -- can create policies for specific sections of application
            services.AddMvc(options =>
                {
                    if (!_env.IsProduction())
                    {
                        options.SslPort = 44388;
                    }
                    options.Filters.Add(new RequireHttpsAttribute());
                    options.Filters.Add(new ValidationAttribute());
                    options.Filters.Add(new ExceptionHandlerFilterAttribute(_loggerFactory));
                })
                .AddControllersAsServices();

            return ConfigureIoC(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (_env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseCors(cfg =>
            //{
            //    cfg.AllowAnyHeader();
            //});
            app.UseAuthentication();
            app.UseMvc();

        }

        public IServiceProvider ConfigureIoC(IServiceCollection services)
        {
            var container = new Container();
            container.Configure(x => x.AddRegistry(new AutoMapRegistry(container)));
            container.Configure(config =>
            {
                config.AddRegistry(new StructureMapRegistry());
                config.Populate(services); 
            });
            
            return container.GetInstance<IServiceProvider>();
        }
    }
}
