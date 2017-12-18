using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ShiftManagementPortal.Core.Repository;
using ShiftManagementPortal.Core.SeedWork;
using ShiftManagementPortal.DependencyResolution.Resolvers;
using ShiftManagementPortal.Infrastructure;
using ShiftManagementPortal.Infrastructure.Data;
using StructureMap;

namespace ShiftManagementPortal.DependencyResolution.Registries
{
    public class StructureMapRegistry : StructureMap.Registry
    {
        public StructureMapRegistry()
        {
            Scan(_ =>
             {
                 _.AssembliesFromApplicationBaseDirectory();
                 _.TheCallingAssembly();
                 _.AssemblyContainingType(typeof(Entity));
                 _.AssemblyContainingType(typeof(SqlBase));
                 _.AddAllTypesOf(typeof(UrlResolver));
                 _.WithDefaultConventions();
                 
             });

            For<IDatabaseContext>().Use(_ => new DatabaseContextFactory().CreateDbContext(null)).Singleton();
            For<IHttpContextAccessor>().Use<HttpContextAccessor>().Singleton();
            
            //config.For<IUnitOfWork>().Use(_ => new UnitOfWork(3)).ContainerScoped();
        }
    }
}
