using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using AutoMapper;
using StructureMap;

namespace ShiftManagementPortal.DependencyResolution.Registries
{
    public class AutoMapRegistry : StructureMap.Registry
    {
        public AutoMapRegistry(IContainer container)
        {
            var config = new MapperConfiguration(cfg => {

                //Allow IoC container to be used to resolve any dependencies
                cfg.ConstructServicesUsing(container.GetInstance);
                cfg.AddProfiles(Assembly.GetExecutingAssembly());
            });
            var mapper = config.CreateMapper();
            For<IMapper>().Use(_ => mapper).Singleton();
        }
    }
}
